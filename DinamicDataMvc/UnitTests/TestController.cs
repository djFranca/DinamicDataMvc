using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Models.Field;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DinamicDataMvc.UnitTests
{
    public class TestController : Controller
    {
        private readonly IMetadataService _MetadataService;
        private readonly IConnectionManagementService _Connection;
        private readonly IFieldService _FieldService;
        private readonly IBranchService _Branch;
        private readonly IKeyGenerates _KeyService;

        public TestController(IConnectionManagementService Connection, IMetadataService MetadataService, IFieldService FieldService, IKeyGenerates KeyService, IBranchService Branch)
        {
            _Connection = Connection;
            _MetadataService = MetadataService;
            _FieldService = FieldService;
            _KeyService = KeyService;
            _Branch = Branch;
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

        [HttpGet("/Test/TestCreateProcess/")]
        public string TestCreateProcess()
        {
            _Connection.DatabaseConnection();
            _MetadataService.SetDatabase(_Connection.GetDatabase());

            _KeyService.SetKey();

            MetadataModel model = new MetadataModel()
            {
                Id = _KeyService.GetKey(),
                Name = "P4",
                Version = 1,
                Date = DateTime.Now.Date,
                State = "5ceac39b5cef382144c73570",
                Field = new List<string>() { "5d2b4fd7af3e31420c45bb70", "5d2b97f4509c780c0c45cd76" },
                Branch = new List<string>() { "5ce95aab70eb31116c6ca8d6" }
            };

            string message = _MetadataService.CreateMetadata(model);
            return message;
        }


        [HttpGet("/Test/GetBranchID/")]
        public string GetBranchID()
        {
            string code = Request.Query["Code"];
            _Connection.DatabaseConnection();
            _Branch.SetDatabase(_Connection.GetDatabase());
            return "Code : " + code + " = ID : " + _Branch.GetBranchID(code);
        }
    }
}