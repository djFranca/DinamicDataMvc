using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers
{
    public class ProcessDetailsController : Controller
    {
        private readonly IConnectionManagement _Connection;
        private IGetProcessDetailsByName _Details;
        private IGetBranchById _Branch;

        public ProcessDetailsController(IConnectionManagement Connection, IGetProcessDetailsByName Details, IGetBranchById Branch)
        {
            _Connection = Connection;
            _Details = Details;
            _Branch = Branch;
        }

        [HttpGet("/ProcessDetails/Details/{id}")]
        public IActionResult Details(string id)
        {
            List<ProcessDetailsModel> ProcessesDetailsList = new List<ProcessDetailsModel>();
            List<string> Branches = null;
            _Connection.DatabaseConnection();
            _Details.SetDatabase(_Connection.GetDatabase());
            _Details.ReadFromTable(id);
            var ModelsList = _Details.GetModels();

            foreach (var model in ModelsList)
            {
                Branches = new List<string>();

                ViewBag.Name = model.Name; //Stores the process name;
                foreach (var branchCode in model.Branch)
                {
                    _Branch.SetDatabase(_Connection.GetDatabase());
                    _Branch.ReadFromDatabase(branchCode);
                    Branches.Add(_Branch.GetBranches());
                }
                ProcessDetailsModel processDetailsModel = new ProcessDetailsModel()
                {
                    Version = "V" + model.Version.ToString(),
                    CreationDate = model.CreatedDate.Date.ToString(),
                    Branches = Branches
                };
                ProcessesDetailsList.Add(processDetailsModel);
            }

            return View(ProcessesDetailsList);
        }

        [HttpGet("/ProcessDetails/ByVersion/{id}")]
        public IActionResult ByVersion(string id)
        {
            ViewBag.Name = Request.Query["Name"];


            //TODO: this model is hardcoded to test view and partial view
            ProcessDetailsModel p = new ProcessDetailsModel()
            {
                Version = "V1",
                CreationDate = "2019/05/21",
                Branches = new List<string>() {"Development", "Quality" }
            };

            return View(p);
        }
    }
}