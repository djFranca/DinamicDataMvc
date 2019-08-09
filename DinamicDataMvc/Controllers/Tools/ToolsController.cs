﻿using DinamicDataMvc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using DinamicDataMvc.Models.Tools;
using DinamicDataMvc.Models.Field;
using DinamicDataMvc.Models;
using DinamicDataMvc.Models.Data;
using DinamicDataMvc.Models.Log;
using DinamicDataMvc.Utils;

namespace DinamicDataMvc.Controllers.Tools
{
    /*
     * Controlador para controlo de funcionalidades do sistema;
     */
    public class ToolsController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IMetadataService _Metadata;
        private readonly IBranchService _Branch;
        private readonly IStateService _State;
        private readonly IKeyGenerates _KeyId;
        private readonly IMessage _Message;
        private readonly IProcessHistory _Log;
        private readonly IFieldService _Field;
        private readonly IPropertyService _Property;

        public ToolsController(IConnectionManagementService Connection, IMetadataService Metadata, IBranchService Branch, IStateService State, IKeyGenerates KeyId, IMessage Message, IProcessHistory Log, IFieldService Field, IPropertyService Property)
        {
            _Connection = Connection;
            _Metadata = Metadata;
            _Branch = Branch;
            _State = State;
            _KeyId = KeyId;
            _Message = Message;
            _Log = Log;
            _Field = Field;
            _Property = Property;
        }


        [HttpGet("/Tools/Dasboard/")]
        public async Task<ActionResult> Dashboard()
        {
            return await Task.Run(() => View("Dashboard"));
        }


        [HttpGet("/Tools/GetAllCollections/")]
        public async Task<ActionResult> GetAllCollections()
        {
            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();

            Dictionary<string, long> map = new Dictionary<string, long>()
            {
                { "Field", await database.GetCollection<FieldModel>("Field").Find(s => true).CountDocumentsAsync()},
                { "Metadata", await database.GetCollection<MetadataModel>("Metadata").Find(s => true).CountDocumentsAsync()},
                { "Branch", await database.GetCollection<BranchModel>("Branch").Find(s => true).CountDocumentsAsync()},
                { "State", await database.GetCollection<StateModel>("State").Find(s => true).CountDocumentsAsync()},
                { "Properties", await database.GetCollection<PropertiesModel>("Properties").Find(s => true).CountDocumentsAsync()},
                { "History", await database.GetCollection<ViewDataModel>("History").Find(s => true).CountDocumentsAsync()}
            };

            List<string> _CollectionNames = database.ListCollectionNames().ToList();
            List<long> _NumberOfDocuments = new List<long>();

            foreach (string name in _CollectionNames)
            {
                long NumberOfDocuments = map[name];
                _NumberOfDocuments.Add(NumberOfDocuments);
            }

            CollectionModel model = new CollectionModel()
            {
                CollectionNames = _CollectionNames,
                NumberOfDocuments = _NumberOfDocuments
            };

            return await Task.Run(() => View("GetAllCollections", model));
        }


        [HttpGet("/Tools/ConnectionInfo/")]
        public async Task<ActionResult> ConnectionInfo()
        {
            _Connection.DatabaseConnection();
            IMongoDatabase database = _Connection.GetDatabase();

            ViewBag.Database = database.DatabaseNamespace.DatabaseName;
            string serverConnectionInfo = _Connection.GetConnectionString();

            ViewBag.Connection = serverConnectionInfo;

            return await Task.Run(() => View("ConnectionInfo"));
        }


        [HttpGet("/Tools/PopulateStateCollection")]
        public async Task<ActionResult> PopulateStateCollection()
        {
            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();
            _State.SetDatabase(database);
            long documentNumber = await database.GetCollection<StateModel>("State").Find(s => true).CountDocumentsAsync();

            ViewBag.Message = _Message.GetMessage(2);
            ViewBag.EmptyCollection = "false";

            if (documentNumber == 0)
            {
                List<StateModel> stateModels = new List<StateModel>();
                _KeyId.SetKey();
                StateModel active = new StateModel()
                {
                    Id = _KeyId.GetKey(),
                    Value = true,
                    Description = "Active"
                };
                stateModels.Add(active);

                _KeyId.SetKey();
                StateModel inactive = new StateModel()
                {
                    Id = _KeyId.GetKey(),
                    Value = false,
                    Description = "Inactive"
                };
                stateModels.Add(inactive);

                _State.CreateState(stateModels);

                ViewBag.Message = _Message.GetMessage(4);
                ViewBag.EmptyCollection = "true";
            }

            List<StateModel> states = _State.GetStateModels();

            return await Task.Run(() => View("PopulateStateCollection", states));
        }


        [HttpGet("/Tools/PopulateBranchCollection")]
        public async Task<ActionResult> PopulateBranchCollection()
        {
            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();
            _Branch.SetDatabase(database);
            long documentNumber = await database.GetCollection<BranchModel>("Branch").Find(s => true).CountDocumentsAsync();

            ViewBag.Message = _Message.GetMessage(1);
            ViewBag.EmptyCollection = "false";

            if (documentNumber == 0)
            {
                List<BranchModel> branchModels = new List<BranchModel>();
                _KeyId.SetKey();
                BranchModel dev = new BranchModel()
                {
                    Id = _KeyId.GetKey(),
                    Code = "Dev",
                    Description = "Development"
                };
                branchModels.Add(dev);

                _KeyId.SetKey();
                BranchModel qa = new BranchModel()
                {
                    Id = _KeyId.GetKey(),
                    Code = "Qa",
                    Description = "Quality"
                };
                branchModels.Add(qa);

                _KeyId.SetKey();
                BranchModel prod = new BranchModel()
                {
                    Id = _KeyId.GetKey(),
                    Code = "Prod",
                    Description = "Production"
                };
                branchModels.Add(prod);

                _Branch.CreateBranch(branchModels);
                ViewBag.Message = _Message.GetMessage(3);
                ViewBag.EmptyCollection = "true";
            }

            List<BranchModel> branches = _Branch.GetBranchModels(); //Obter todos os branch models armazenados na colecção Branch;

            return await Task.Run(() => View("PopulateBranchCollection", branches));
        }


        [HttpPost("/Tools/WebFormGenerator/")]
        public async Task<ActionResult> WebFormGenerator()
        {
            ViewBag.Fragment1 = "<div class='container'><h1>Login Page</h1></div>";
            ViewBag.Fragment2 = "<div class='container'><label><b>Username</b></label><br /><input type='email' value='123456@email.com' size='25' maxlength='20' name='email_22 /></div><br />";
            ViewBag.Fragment3 = "<div class='container'><label><b>Password</b></label><br /><input type='password' value='123456' size='25' maxlength='50' name='password_22 /></div><br />";
            ViewBag.Fragment4 = "<div class='container'><button type='submit'> Login </button></div>";
            return await Task.Run(() => View("WebFormGenerator"));
        }


        [HttpGet("/Tools/GetProcessLogs/")]
        public async Task<ActionResult> GetProcessLogs()
        {
            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();
            _Log.SetDatabase(database);
            List<LogModel> logs = _Log.GetProcessesLogs();

            return await Task.Run(() => View("GetProcessLogs", logs));
        }


        [HttpPost("/Tools/CreateWebForm/")]
        public async Task<ActionResult> CreateWebForm(List<string> fields)
        {
            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();
            _Field.SetDatabase(database);
            _Property.SetDatabase(database);

            List<WebFormModel> webFormElements = new List<WebFormModel>();

            foreach(string field in fields)
            {
                FieldModel fieldModel = _Field.GetField(field);
                PropertiesModel propertiesModel = _Property.GetProperties(fieldModel.Properties);

                WebFormModel webFormElement = new WebFormModel()
                {
                    Type = fieldModel.Type,
                    Name = fieldModel.Name,
                    Size = propertiesModel.Size.ToString(),
                    Value = propertiesModel.Value,
                    Maxlength = propertiesModel.Maxlength.ToString(),
                    Required = propertiesModel.Required.ToString()
                };

                webFormElements.Add(webFormElement);
            }

            //Passar a lista de webform elements a uma classe que vai criar uma array com as linhas a serem renderizadas;
            WebFormTemplate webFormTemplate = new WebFormTemplate(webFormElements);
            List<string> fragments = webFormTemplate.Template();

            string template = string.Empty;
            for(int j = 0; j < fragments.Count; j++)
            {
                if(j == fragments.Count - 1)
                {
                    template += fragments[j];
                }
                else
                {
                    template += (fragments[j] + "|");
                }
            }

            ViewBag.Template = template;

            return await Task.Run(() => View("CreateWebForm"));
        }
    }
}