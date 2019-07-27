using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Field;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers.Properties
{
    public class PropertiesController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IFieldService _Field;

        public PropertiesController(IConnectionManagementService Connection, IFieldService Field)
        {
            _Connection = Connection;
            _Field = Field;
        }

        [HttpPost("/Properties/Details")]
        public async Task<ActionResult> Details(string propertiesId, string processName, string processVersion, string fieldType, string fieldName)
        {
            ViewBag.ProcessName = processName;
            ViewBag.ProcessVersion = processVersion;
            ViewBag.FieldName = fieldName;
            ViewBag.FieldType = fieldType;

            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            PropertiesModel propertiesModel = _Field.GetProperties(propertiesId);
            return await Task.Run(() => View("Details", propertiesModel));
        }
    }
}