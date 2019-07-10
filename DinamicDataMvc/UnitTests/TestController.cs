using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.UnitTests
{
    public class TestController : Controller
    {
        private readonly IMetadataService _MetadataService;
        private readonly IConnectionManagementService _Connection;

        public TestController(IConnectionManagementService Connection, IMetadataService MetadataService)
        {
            _Connection = Connection;
            _MetadataService = MetadataService;
        }

        [HttpGet]
        public string TestGetProcessByVersion()
        {
            _Connection.DatabaseConnection();
            _MetadataService.SetDatabase(_Connection.GetDatabase());
            MetadataModel model = _MetadataService.GetProcessByVersion("P1", 1);
            string message = "Nome = " + model.Name + ", Version = " + model.Version + ", Creation Date = " + model.Date + ", State = " + model.State;
            return message;
        }
    }
}