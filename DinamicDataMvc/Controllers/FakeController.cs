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

        public FakeController(IConnectionManagement Connection, IGetProcessesMetadata Metadata)
        {
            _Connection = Connection;
            _GetMetadata = Metadata;
        }

        [Route("/Fake/TestDatabaseConnection/")]
        public string TestDatabaseConnection()
        {
            _Connection.DatabaseConnection();
            IMongoDatabase database = _Connection.GetDatabase();

            return "Your work database name is: " + database.DatabaseNamespace.DatabaseName;
        }


        [Route("/Fake/TestGetMetadataList")]
        public List<MetadataModel> TestMetadataList()
        {
            _GetMetadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;
            _GetMetadata.SetFilterParameters("P2", 1); //Definem-se parâmetros de filtragem de informação
            _GetMetadata.ReadFromDatababe(); //Procede-se à leitura da base de dados;
            return _GetMetadata.GetProcessesMetadataList();
        }
    }
}