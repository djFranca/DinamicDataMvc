using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers
{
    public class FieldController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IMetadataService _Processes;
        private readonly IFieldService _Field;

        public FieldController(IConnectionManagementService Connection, IMetadataService Processes, IFieldService Field)
        {
            _Connection = Connection;
            _Processes = Processes;
            _Field = Field;
        }

        [HttpGet("/Field/GetFields")]
        public IActionResult GetFields()
        {
            _Connection.DatabaseConnection();
            _Processes.SetDatabase(_Connection.GetDatabase());
            _Processes.ReadFromDatababe();
            var models = _Processes.GetProcessesMetadataList();

            return View(models);
        }

        [HttpGet("/Field/Index")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("/Field/Create")]
        public IActionResult Create(string type)
        {
            var _type= type.ToLower();
            InputModel model = null;

            if (_type.Equals("password"))
            {
                model = new InputModel()
                {
                    Type = "Password"
                };
                
            }
            return View("Create", model);
        }

        [HttpPost("/Field/AddField")]
        public string AddField(InputModel model)
        {
            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());

            _Field.CreateInputField(model);

            return "successful insertion";
        }
    }
}