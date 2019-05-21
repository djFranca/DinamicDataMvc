using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers
{
    public class DataController : Controller
    {

        private readonly IMetadata _tempData;

        public DataController(IMetadata tempData)
        {
            _tempData = tempData;
        }

        [HttpGet("data/index")]
        public IActionResult Index()
        {
            var items = _tempData.GetAllMetadata(null, null, null);
            return View(items);
        }
    }
}