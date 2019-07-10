using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Models.Field;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers.Field
{
    public class FieldController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IFieldService _Field;

        public FieldController(IConnectionManagementService Connection, IFieldService Field)
        {
            _Connection = Connection;
            _Field = Field;
        }

        [HttpGet("/Field/Read")]
        public async Task<ActionResult> Read()
        {
            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            _Field.ReadFromDatabase();
            List<FieldModel> models = _Field.GetFields();

            return await Task.Run(() => View("Read", models));
        }


        [HttpPost("/Field/Create")]
        public async Task<ActionResult> Create(string type)
        {
            return await Task.Run(() => View("Create"));
        }

        [HttpGet]
        public async Task<ActionResult> Display()
        {
            return await Task.Run(() => View("Display"));
        }



        [HttpGet("/Field/Delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            string request = id;

            return await Task.Run(() => View("Delete"));
        }



        [HttpPost("/Field/AddField")]
        public string AddField()
        {
            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());

            //_Field.CreateInputField(model);

            return "successful insertion";
        }
    }
}