using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Metadata;
using DinamicDataMvc.Models.Field;
using Microsoft.AspNetCore.Mvc;
using DinamicDataMvc.Models.Properties;

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
            if(metadata.Field.Count() > 0)
            {
                foreach (var field in metadata.Field)
                {
                    fields.Add(_Field.GetField(field)); //Adiciona o modelo criado para cada campo (Field) a uma lista do tipo FieldModel;
                }
            }

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

            if (modelsToDisplay.Count == 0) //Se não existirem campos para mostrar na listagem
            {
                List<FieldModel> auxModels = new List<FieldModel>();
                FieldModel defaultModel = new FieldModel()
                {
                    Id = string.Empty,
                    Name = string.Empty,
                    Type = string.Empty,
                    Date = DateTime.Now.ToLocalTime(),
                    Properties = string.Empty
                };
                auxModels.Add(defaultModel);
                modelsToDisplay.Add(Convert.ToInt32(pageNumber), auxModels);
                return await Task.Run(() => View("Read", auxModels));
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


        /*
         * Action - Apaga do processo o campo cujo identificador é recebido como parâmetro de entrada do controlador;
         */
        [HttpPost("/Field/Delete/")]
        public string Delete(string FieldId)
        {
            if(string.IsNullOrEmpty(FieldId))
            {
                return NotFound().StatusCode.ToString();
            }
            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            return _Field.DeleteField(FieldId);
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
                Date = DateTime.Now.ToLocalTime()
            };

            _Connection.DatabaseConnection();
            
            _Properties.SetDatabase(_Connection.GetDatabase());
            _Properties.CreateProperties(properties);

            _Field.SetDatabase(_Connection.GetDatabase());
            _Field.CreateField(field);

            _Metadata.SetProcessVersion(model.ProcessID);
            _Metadata.AddFieldToProcess(model.ProcessID, fieldId);

            //_Field.ReadFromDatabase();

            return await Task.Run(() => RedirectToAction("Read", "Field", new { ProcessId = model.ProcessID })); //Antes no action estava display;
        }


        [HttpPost("/Field/DeleteOnUpdate/")]
        public async Task<ActionResult> DeleteOnUpdate(string ProcessID, string FieldID)
        {
            _Connection.DatabaseConnection();
            _Metadata.SetDatabase(_Connection.GetDatabase());
            _Field.SetDatabase(_Connection.GetDatabase());
            _Properties.SetDatabase(_Connection.GetDatabase());

            MetadataModel metadata = _Metadata.GetMetadata(ProcessID); //Obtem-se os metadados do processo cujo o id foi recebido como argumento de entrada;
            FieldModel fieldToDelete = _Field.GetField(FieldID); //Obtem-se o modelo do campo a remover da base de dados;

            _Properties.DeleteProperties(fieldToDelete.Properties); //Apaga as propriedades agregadas ao campo;
            _Field.DeleteField(FieldID); //Apaga o campo agregado ao processo;

            List<string> UpdatedFields = new List<string>();
            foreach(string field in metadata.Field)
            {
                if (!field.Equals(FieldID.ToUpper()))
                {
                    UpdatedFields.Add(field);
                }
            }
            metadata.Field = UpdatedFields;

            _Metadata.ReplaceMetadata(ProcessID, metadata); //Efetua o replace do modelo de dados MetadataModel existente pelo novo modelo atualizado;

            return await Task.Run(() => RedirectToAction("Read", "Field", new { ProcessId = ProcessID })); //Antes no action estava display;
        }
    }
}