using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using PagedList;
using System.Threading.Tasks;

namespace DinamicDataMvc.Tests
{
    /*
     * Contolador de Teste para testar individualmente os diversos serviços,
     * criados para tratar os pedidos dos utilizadores;
     */
    public class FakeController : Controller
    {
        private readonly IConnectionManagement _Connection;
        private readonly IGetProcessesMetadata _GetMetadata;
        private readonly IGetBranchById _GetBranchById;
        private readonly IGetStateById _GetStateById;

        public FakeController(IConnectionManagement Connection, IGetProcessesMetadata Metadata, IGetBranchById Branch, IGetStateById State)
        {
            _Connection = Connection;
            _GetMetadata = Metadata;
            _GetBranchById = Branch;
            _GetStateById = State;
        }

        [Route("/Fake/TestDatabaseConnection/")]
        public string TestDatabaseConnection()
        {
            _Connection.DatabaseConnection();
            IMongoDatabase database = _Connection.GetDatabase();

            return "Your work database name is: " + database.DatabaseNamespace.DatabaseName;
        }



        [Route("/Fake/TestMetadataList")]
        public IActionResult TestMetadataList()
        {
            List<MetadataListModel> ListModel = new List<MetadataListModel>();

            _Connection.DatabaseConnection();
            _GetMetadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;

            //_GetMetadata.SetFilterParameters("P1", 1); //Definem-se parâmetros de filtragem de informação
            _GetMetadata.ReadFromDatababe(); //Procede-se à leitura da base de dados;

            List<MetadataModel> Model = _GetMetadata.GetProcessesMetadataList();

            foreach (var item in Model)
            {
                string Name = String.Empty;
                string Version = String.Empty;
                string Date = String.Empty;
                List<string> Branch = new List<string>();
                string State = String.Empty;

                Name = item.Name;
                Version = "V" + item.Version.ToString();
                Date = item.CreatedDate.ToShortDateString();

                _GetBranchById.SetDatabase(_Connection.GetDatabase());

                foreach (var id in item.Branch)
                {
                    _GetBranchById.ReadFromDatabase(id);
                    var branch = _GetBranchById.GetBranches();
                    Branch.Add(branch);
                }

                _GetStateById.SetDatabase(_Connection.GetDatabase());
                _GetStateById.ReadFromDatabase(item.State);
                State = _GetStateById.GetStateDescription();

                MetadataListModel _model = new MetadataListModel()
                {
                    Name = Name,
                    Version = Version,
                    Date = Date,
                    Branch = Branch,
                    State = State
                };

                ListModel.Add(_model);
            }


            return View(ListModel);
        }



        [Route("/Fake/TestBranchList/")]
        public string TestBranchList()
        {
            _Connection.DatabaseConnection();
            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetBranchById.ReadFromDatabase("5ce95b7970eb31116c6ca8d7");
            return _GetBranchById.GetBranches();
        }

        [Route("/Fake/TestState")]
        public string TestState()
        {
            _Connection.DatabaseConnection();
            _GetStateById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.ReadFromDatabase("5ceac39b5cef382144c73570");


            return _GetStateById.GetStateDescription();
        }

        [Route("/Fake/ProcessDetails")]
        public string ProcessDetails()
        {
            return "Success";
        }
    }
}