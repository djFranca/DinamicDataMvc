using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers
{
    public class FieldController : Controller
    {
        private readonly IConnectionManagement _Connection;
        private readonly IMetadataService _Processes;

        public FieldController(IConnectionManagement Connection, IMetadataService Processes)
        {
            _Connection = Connection;
            _Processes = Processes;
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
    }
}