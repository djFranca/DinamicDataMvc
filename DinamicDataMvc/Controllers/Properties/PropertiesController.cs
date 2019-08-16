using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Properties;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers.Properties
{
    public class PropertiesController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IPropertyService _Properties;

        public PropertiesController(IConnectionManagementService Connection, IPropertyService Properties)
        {
            _Connection = Connection;
            _Properties = Properties;
        }

        [HttpPost("/Properties/Details")]
        public async Task<ActionResult> Details(string propertiesId, string processName, string processVersion, string fieldType, string fieldName)
        {
            ViewBag.ProcessName = processName;
            ViewBag.ProcessVersion = processVersion;
            ViewBag.FieldName = fieldName;
            ViewBag.FieldType = fieldType;

            _Connection.DatabaseConnection();
            _Properties.SetDatabase(_Connection.GetDatabase());
            PropertiesModel propertiesModel = _Properties.GetProperties(propertiesId);
            return await Task.Run(() => View("Details", propertiesModel));
        }
    }
}