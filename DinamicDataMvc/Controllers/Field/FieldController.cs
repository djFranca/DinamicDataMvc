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
        private readonly IKeyGenerates _KeyId;
        private readonly IPaginationService _SetPagination;
        private readonly IMetadataService _Metadata;
        private readonly IBranchService _Branch;
        private readonly IStateService _State;

        public FieldController(IConnectionManagementService Connection, IMetadataService Metadata, IFieldService Field, IPropertyService Properties, IKeyGenerates KeyId, IPaginationService SetPagination, IBranchService Branch, IStateService State)
        {
            _Connection = Connection;
            _Field = Field;
            _Properties = Properties;
            _KeyId = KeyId;
            _SetPagination = SetPagination;
            _Metadata = Metadata;
            _Branch = Branch;
            _State = State;
        }

        [HttpGet("/Field/Read/")]
        public async Task<ActionResult> Read()
        {
            string processId = Request.Query["ProcessId"];
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

            List<FieldModel> fields = new List<FieldModel>(); //Armazena os campos existentes no processo;

            //1º Passo - Obter o Metadata Model correspondente ao id fornecido;
            MetadataModel metadata = _Metadata.GetMetadata(processId);

            //2º Passo - Obter os Field Models agregados a cada processo;
            foreach(var field in metadata.Field)
            {
                fields.Add(_Field.GetField(field)); //Adiciona o modelo criado para cada campo (Field) a uma lista do tipo FieldModel;
            }

            ////1º Passo - Obter os objetos FieldModel e PropertiesModel agregados à versão anterior e passados no Modelo de dados MetadataModel;
            ////-----------------------------------------------------
            ////Sistema independente - Utils
            ////-----------------------------------------------------
            //List<string> fieldIdKeys = new List<string>(); //Armazena a lista de novos ids dos campos do processo atualizado;

            //foreach(var field in metadataModel.Field)
            //{
            //    FieldModel model = _Field.GetField(field);
            //    fieldClones.Add(model);
            //}

            //foreach (var fieldCloned in fieldClones)
            //{
            //    PropertiesModel model = _Field.GetProperties(fieldCloned.Properties);
            //    _KeyId.SetKey(); //Gera um novo object id para criar uma nova coleção na tabela de propriedades;
            //    model.ID = _KeyId.GetKey(); //Afecta o novo identificador object id ao modelo de dados properties;
            //    _Field.CreateProperties(model); //cria um novo modelo de dados do tipo propriedades;
            //    fieldCloned.Properties = model.ID; //Afecta o id dessas propriedades criadas ao campo do novo processo

            //    _KeyId.SetKey(); //Gera um novo object id para criar uma nova coleção na tabela de campos;
            //    fieldCloned.Id = _KeyId.GetKey(); //Afecta o novo identificador object id ao modelo de dados properties;
            //    fieldIdKeys.Add(fieldCloned.Id); //Armazena na lista de novas keys referentes aos campos clonados o id do campo clonado;
            //    _Field.CreateField(fieldCloned); //cria um novo modelo de dados do tipo campos;
            //}
            ////-----------------------------------------------------

            ////2º Passo - obter a designação dos branches em que se encontra o processo;
            //List<string> branches = new List<string>();
            //foreach(var branch in metadataModel.Branch)
            //{
            //    branches.Add(_Branch.GetBranchID(branch));
            //}

            ////3º Passo - Cria e armazena na base de dados uma nova versão do processo atualizado;
            //MetadataModel UpdatedMetadataModel = new MetadataModel()
            //{
            //    Id = metadataModel.Id,
            //    Name = metadataModel.Name,
            //    Version = metadataModel.Version,
            //    Date = Convert.ToDateTime(metadataModel.Date),
            //    State = _State.GetStateID(metadataModel.State),
            //    Field = fieldIdKeys,
            //    Branch = branches
            //};
            //_Metadata.CreateMetadata(UpdatedMetadataModel); //

            //3º Passo - Injetar na página as informações relativas ao processo pai dos campos agregados;
            ViewBag.ProcessId = metadata.Id;
            ViewBag.ProcessName = metadata.Name;
            ViewBag.processVersion = metadata.Version.ToString();
            ViewBag.ProcessDate = metadata.Date.ToString().Substring(0, 10);
            _State.ReadFromDatabase(metadata.State);
            ViewBag.ProcessState = _State.GetStateDescription();

            Dictionary<int, List<FieldModel>> modelsToDisplay = _SetPagination.SetModelsByPage(fields);

            int NumberOfPages = modelsToDisplay.Count();
            ViewBag.NumberOfPages = NumberOfPages;

            if(modelsToDisplay.Count == 0) //Se não existirem campos para mostrar na listagem
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
            _KeyId.SetKey(); //Sets a new properties ObjectID collection;
            string propertiesId = _KeyId.GetKey();

            //First must create properties model;
            PropertiesModel properties = new PropertiesModel()
            {
                ID = propertiesId,
                Size = Convert.ToInt32(model.Size),
                Value = model.Value,
                Maxlength = Convert.ToInt32(model.Maxlength),
                Required = Convert.ToBoolean(model.Required)
            };

            _KeyId.SetKey(); //Sets a new properties ObjectID collection;
            string fieldId = _KeyId.GetKey();

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

            return await Task.Run(() => RedirectToAction("Read", "Field", new { ProcessId = model.ProcessID })); //Antes na action estava display;
        }







        //[HttpPost("/Field/Update/")]
        //public async Task<ActionResult> Update(string Id)
        //{
        //    _Connection.DatabaseConnection();
        //    _Field.SetDatabase(_Connection.GetDatabase());
        //    FieldModel field = _Field.GetField(Id);
        //    PropertiesModel properties = _Field.GetProperties(field.Properties);

        //    ViewBag.FieldId = Id;
        //    ViewBag.PropertiesID = field.Properties;

        //    ViewFieldModel ViewModel = new ViewFieldModel()
        //    {
        //        Type = field.Type,
        //        Name = field.Name,
        //        Size = properties.Size.ToString(),
        //        Value = properties.Value,
        //        Maxlength = properties.Maxlength.ToString(),
        //        Required = properties.Required.ToString(),
        //        CreationDate = Convert.ToDateTime(field.Date).ToString().Substring(0, 10)
        //    };

        //    return await Task.Run(() => View("Update", ViewModel));
        //}

        //[HttpPost("/Field/SaveUpdate/")]
        //public async Task<ActionResult> SaveUpdate(string fieldId, string propertiesId, ViewFieldModel model)
        //{
        //    //string x = fieldId;
        //    //string y = propertiesId;

        //    _Connection.DatabaseConnection();
        //    _Field.SetDatabase(_Connection.GetDatabase());

        //    _Field.UpdateField(fieldId, new FieldModel()
        //    {
        //        Id = fieldId,
        //        Type = model.Type,
        //        Name = model.Name,
        //        Properties = propertiesId,
        //        Date = Convert.ToDateTime(model.CreationDate)
        //    });

        //    _Field.UpdateProperties(propertiesId, new PropertiesModel()
        //    {
        //        ID = propertiesId,
        //        Size = Convert.ToInt32(model.Size),
        //        Value = model.Value,
        //        Maxlength = Convert.ToInt32(model.Maxlength),
        //        Required = Convert.ToBoolean(model.Required)
        //    });


        //    return await Task.Run(() => RedirectToAction("Read", "Field"));
        //}
    }
}