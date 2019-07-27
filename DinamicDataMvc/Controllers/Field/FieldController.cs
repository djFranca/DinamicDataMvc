using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Models.Field;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers.Field
{
    public class FieldController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IFieldService _Field;
        private readonly IPropertyService _Properties;
        private readonly IKeyGenerates _ObjectId;
        private readonly IPaginationService _SetPagination;
        private readonly IMetadataService _Metadata;
        private readonly IBranchService _Branch;
        private readonly IStateService _State;

        public FieldController(IConnectionManagementService Connection, IMetadataService Metadata, IFieldService Field, IPropertyService Properties, IKeyGenerates ObjectId, IPaginationService SetPagination, IBranchService Branch, IStateService State)
        {
            _Connection = Connection;
            _Field = Field;
            _Properties = Properties;
            _ObjectId = ObjectId;
            _SetPagination = SetPagination;
            _Metadata = Metadata;
            _Branch = Branch;
            _State = State;
        }

        [HttpPost("/Field/Read/")]
        public async Task<ActionResult> Read(MetadataModel metadataModel)
        {
            string pageNumber = Request.Query["Page"];

            if(pageNumber == null)
            {
                pageNumber = 1.ToString();
            }

            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            _Metadata.SetDatabase(_Connection.GetDatabase());
            _Branch.SetDatabase(_Connection.GetDatabase());
            _State.SetDatabase(_Connection.GetDatabase());
            
            //1º Passo - adicionar os campos já existentes na versão anterior para na eventualidade de o utilizador os pretender manter;
            MetadataModel oldVersionProcess = _Metadata.GetProcessByVersion(metadataModel.Name, metadataModel.Version - 1);

            //2º Passo - obter a designação dos branches em que se encontra o processo;
            List<string> branches = new List<string>();
            foreach(var branch in metadataModel.Branch)
            {
                branches.Add(_Branch.GetBranchID(branch));
            }

            //3º Passo - Cria e armazena na base de dados uma nova versão do processo atualizado;
            MetadataModel UpdatedMetadataModel = new MetadataModel()
            {
                Id = metadataModel.Id,
                Name = metadataModel.Name,
                Version = metadataModel.Version,
                Date = Convert.ToDateTime(metadataModel.Date),
                State = _State.GetStateID(metadataModel.State),
                Field = oldVersionProcess.Field,
                Branch = branches
            };

            _Metadata.CreateMetadata(UpdatedMetadataModel); //

            //4º Passo - Obter a lista de Field Models que um processo têm agregado;
            List<FieldModel> viewFieldModels = new List<FieldModel>();

            foreach(var fieldId in oldVersionProcess.Field)
            {
                FieldModel fieldModel = _Field.GetField(fieldId);
                viewFieldModels.Add(fieldModel);
            }

            Dictionary<int, List<FieldModel>> modelsToDisplay = _SetPagination.SetModelsByPage(viewFieldModels);

            int NumberOfPages = modelsToDisplay.Count();
            ViewBag.NumberOfPages = NumberOfPages;


            //Se não existirem campos para mostrar na listagem
            if(modelsToDisplay.Count == 0)
            {
                List<FieldModel> models = new List<FieldModel>();
                FieldModel model = new FieldModel()
                {
                    Id = string.Empty,
                    Name = string.Empty,
                    Type = string.Empty,
                    Date = DateTime.Now,
                    Properties = string.Empty
                };
                return await Task.Run(() => View("Read", models));
            }

            return await Task.Run(() => View("Read", modelsToDisplay[Convert.ToInt32(pageNumber)]));
        }







        [HttpGet("/Field/Display/")]
        public async Task<ActionResult> Display(string id)
        {
            ViewBag.ID = id;
            return await Task.Run(() => View("Display"));
        }

        [HttpPost("/Field/Create/")]
        public async Task<ActionResult> Create()
        {
            ViewBag.Type = Request.Query["Type"];
            ViewBag.ID = Request.Query["Process"];

            return await Task.Run(() => View("Create"));
        }

        [HttpPost("/Field/Delete/")]
        public string Delete(string id)
        {
            if(id == null)
            {
                return NotFound().StatusCode.ToString();
            }
            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            var message = _Field.Delete(id);

            return message;
        }

        [HttpPost("/Field/AddField/")]
        public async Task<ActionResult> AddField(ViewFieldModel model)
        {
            //Defines the properties model key
            _ObjectId.SetKey(); //Sets a new properties ObjectID collection;
            string propertiesId = _ObjectId.GetKey();

            //First must create properties model;
            PropertiesModel properties = new PropertiesModel()
            {
                ID = propertiesId,
                Size = Convert.ToInt32(model.Size),
                Value = model.Value,
                Maxlength = Convert.ToInt32(model.Maxlength),
                Required = Convert.ToBoolean(model.Required)
            };

            _ObjectId.SetKey(); //Sets a new properties ObjectID collection;
            string fieldId = _ObjectId.GetKey();

            //Third creates field model
            FieldModel field = new FieldModel()
            {
                Id = fieldId,
                Name = model.Name,
                Type = model.Type,
                Properties = propertiesId,
                Date = Convert.ToDateTime(model.CreationDate)
            };

            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            _Field.CreateProperties(properties);
            _Field.CreateField(field);

            _Metadata.SetProcessVersion(model.ProcessID);
            _Metadata.AddFieldToProcess(model.ProcessID, fieldId);

            _Field.ReadFromDatabase();

            return await Task.Run(() => RedirectToAction("Display", "Field", new { ID = model.ProcessID }));
        }




        [HttpPost("/Field/Update/")]
        public async Task<ActionResult> Update(string Id)
        {
            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            FieldModel field = _Field.GetField(Id);
            PropertiesModel properties = _Field.GetProperties(field.Properties);

            ViewBag.FieldId = Id;
            ViewBag.PropertiesID = field.Properties;

            ViewFieldModel ViewModel = new ViewFieldModel()
            {
                Type = field.Type,
                Name = field.Name,
                Size = properties.Size.ToString(),
                Value = properties.Value,
                Maxlength = properties.Maxlength.ToString(),
                Required = properties.Required.ToString(),
                CreationDate = Convert.ToDateTime(field.Date).ToString().Substring(0, 10)
            };

            return await Task.Run(() => View("Update", ViewModel));
        }

        [HttpPost("/Field/SaveUpdate/")]
        public async Task<ActionResult> SaveUpdate(string fieldId, string propertiesId, ViewFieldModel model)
        {
            //string x = fieldId;
            //string y = propertiesId;

            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());

            _Field.UpdateField(fieldId, new FieldModel()
            {
                Id = fieldId,
                Type = model.Type,
                Name = model.Name,
                Properties = propertiesId,
                Date = Convert.ToDateTime(model.CreationDate)
            });

            _Field.UpdateProperties(propertiesId, new PropertiesModel()
            {
                ID = propertiesId,
                Size = Convert.ToInt32(model.Size),
                Value = model.Value,
                Maxlength = Convert.ToInt32(model.Maxlength),
                Required = Convert.ToBoolean(model.Required)
            });


            return await Task.Run(() => RedirectToAction("Read", "Field"));
        }
    }
}