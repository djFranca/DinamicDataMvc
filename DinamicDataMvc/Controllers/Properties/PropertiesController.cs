using System.Threading.Tasks;
using DinamicDataMvc.Models.Field;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers.Properties
{
    public class PropertiesController : Controller
    {
        public async Task<ActionResult> DisplayProperties(PropertiesModel model)
        {
            return await Task.Run(() => View("DisplayProperties", model));
        }
    }
}