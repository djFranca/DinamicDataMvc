using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
