using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DinamicDataMvc.Controllers.Home
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> HomePage()
        {
            return await Task.Run(() => View("HomePage"));
        }
    }
}
