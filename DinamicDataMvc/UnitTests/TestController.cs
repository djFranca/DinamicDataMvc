using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Models.Field;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.UnitTests
{
    public class TestController : Controller
    {
        private readonly IMetadataService _MetadataService;
        private readonly IConnectionManagementService _Connection;
        private readonly IFieldService _FieldService;
        private readonly IKeyGenerates _KeyService;

        public TestController(IConnectionManagementService Connection, IMetadataService MetadataService, IFieldService FieldService, IKeyGenerates KeyService)
        {
            _Connection = Connection;
            _MetadataService = MetadataService;
            _FieldService = FieldService;
            _KeyService = KeyService;
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


        [HttpGet]
        public string TestGetProperties(string id)
        {
            _Connection.DatabaseConnection();
            _FieldService.SetDatabase(_Connection.GetDatabase());
            PropertiesModel model = _FieldService.GetProperties(id);
            string message = "ID = " + model.ID + ", Maxlength = " + model.Maxlength + ", Size = " + model.Size + ", Value = " + model.Value + ", Required =" + model.Required;
            return message;
        }

        [HttpGet]
        public string TestKeyGenerates()
        {
            _KeyService.SetKey();
            return _KeyService.GetKey();
        }
    }
}