using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System.Collections.Generic;

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

        public FakeController(IConnectionManagement Connection, IGetProcessesMetadata Metadata, IGetBranchById Branch)
        {
            _Connection = Connection;
            _GetMetadata = Metadata;
            _GetBranchById = Branch;
        }

        [Route("/Fake/TestDatabaseConnection/")]
        public string TestDatabaseConnection()
        {
            _Connection.DatabaseConnection();
            IMongoDatabase database = _Connection.GetDatabase();

            return "Your work database name is: " + database.DatabaseNamespace.DatabaseName;
        }


        [Route("/Fake/TestMetadataList")]
        public List<MetadataModel> TestMetadataList()
        {
            _Connection.DatabaseConnection();
            _GetMetadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;
            _GetMetadata.SetFilterParameters("P1", 1); //Definem-se parâmetros de filtragem de informação
            _GetMetadata.ReadFromDatababe(); //Procede-se à leitura da base de dados;
            return _GetMetadata.GetProcessesMetadataList();
        }

        [Route("/Fake/TestBranchList/")]
        public List<string> TestBranchList()
        {
            _Connection.DatabaseConnection();
            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetBranchById.ReadFromDatabase("5ce95b7970eb31116c6ca8d7");
            return _GetBranchById.GetBranches();
        }
    }
}