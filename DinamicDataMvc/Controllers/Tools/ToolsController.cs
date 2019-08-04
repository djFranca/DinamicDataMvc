﻿using DinamicDataMvc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using DinamicDataMvc.Models.Tools;
using DinamicDataMvc.Models.Field;
using DinamicDataMvc.Models;
using DinamicDataMvc.Models.Data;

namespace DinamicDataMvc.Controllers.Tools
{
    /*
     * Contolador de Teste para testar individualmente os diversos serviços,
     * criados para tratar os pedidos dos utilizadores;
     */
    public class ToolsController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IMetadataService _Metadata;
        private readonly IBranchService _Branch;
        private readonly IStateService _State;
        private readonly IKeyGenerates _KeyId;
        private readonly IMessage _Message;

        public ToolsController(IConnectionManagementService Connection, IMetadataService Metadata, IBranchService Branch, IStateService State, IKeyGenerates KeyId, IMessage Message)
        {
            _Connection = Connection;
            _Metadata = Metadata;
            _Branch = Branch;
            _State = State;
            _KeyId = KeyId;
            _Message = Message;
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
                { "Data", await database.GetCollection<ViewDataModel>("Data").Find(s => true).CountDocumentsAsync()}
            };

            List<string> _CollectionNames = database.ListCollectionNames().ToList();
            List<long> _NumberOfDocuments = new List<long>();

            foreach(string name in _CollectionNames)
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
    }
}