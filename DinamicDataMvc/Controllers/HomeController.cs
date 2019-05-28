using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DinamicDataMvc.Models;
using DinamicDataMvc.Interfaces;
using MongoDB.Driver;

namespace DinamicDataMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConnectionManagement _Connection;

        public HomeController(IConnectionManagement DatabaseConnection)
        {
            _Connection = DatabaseConnection;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        public string DatabaseTest()
        {
            _Connection.DatabaseConnection();
            IMongoDatabase database = _Connection.GetDatabase();

            return database.DatabaseNamespace.DatabaseName;
        }
    }
}
