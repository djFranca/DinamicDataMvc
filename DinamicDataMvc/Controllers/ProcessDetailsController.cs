using System;
using System.Collections.Generic;
using System.Linq;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers
{
    public class ProcessDetailsController : Controller
    {
        private readonly IConnectionManagement _Connection;
        private readonly IGetProcessDetailsByName _Details;
        private readonly IGetBranchById _Branch;
        private readonly IGetProcessDetailsByName _Process;
        private readonly IVersionNumber _VersionCode;
        private readonly IGetDataById _Data;

        public ProcessDetailsController(IConnectionManagement Connection, IGetProcessDetailsByName Details, IGetBranchById Branch, IGetProcessDetailsByName Process, IVersionNumber VersionCode, IGetDataById Data)
        {
            _Connection = Connection;
            _Details = Details;
            _Branch = Branch;
            _Process = Process;
            _VersionCode = VersionCode;
            _Data = Data;
        }

        [HttpGet("/ProcessDetails/Details/{id}")]
        public IActionResult Details(string id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            List<ProcessDetailsModel> ProcessesDetailsList = new List<ProcessDetailsModel>();
            _Connection.DatabaseConnection();
            _Details.SetDatabase(_Connection.GetDatabase());
            _Details.ReadFromTable(id);
            var ModelsList = _Details.GetModels();

            foreach (var model in ModelsList)
            {
                List<string> Branches = new List<string>();

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
            //Se o valor do identificador, for nulo ou vazio, o controlador devolve o status: BadRequest() --> error 400; 
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            string name = Request.Query["Name"];
            ViewBag.Name = name;

            _VersionCode.SetNumber(id);
            int versionNumber = _VersionCode.GetVersionNumber();

            List<string> branchList = new List<string>();

            _Connection.DatabaseConnection(); //Estabeleçe-se a conexão com a base de dados;
            var _database = _Connection.GetDatabase(); //Obtêm-se a base de dados pretendida para trabalhar as coleções de dados;
            _Process.SetDatabase(_database); //A base de dados em contexto é passada ao serviço;
            _Process.ReadFromTable(name); //Obtem-se da tabela Metadata 
            List<MetadataModel> models = _Process.GetModels(); //Armazena os modelos retornados que satisfaçam a condição ter um nome igual ao recebido

            MetadataModel filteredModel = null;
            foreach(var model in models)
            {
                if (model.Version == versionNumber)
                {
                    filteredModel = model;
                }
            }

            foreach(var branch in filteredModel.Branch)
            {
                _Branch.SetDatabase(_database);
                _Branch.ReadFromDatabase(branch);
                branchList.Add(_Branch.GetBranches());
            }

            List<DataProcessModel> DataModelsList = new List<DataProcessModel>();
           
            foreach(var itemId in filteredModel.Data)
            {
                _Data.SetDatabase(_database);
                _Data.ReadFromDatabase(itemId);
                DataProcessModel model = _Data.GetModel();
                DataModelsList.Add(model);
            }

            ViewBag.Data = DataModelsList;

            ProcessDetailsModel filteredProcess = new ProcessDetailsModel()
            {
                Version = "V" + filteredModel.Version.ToString(),
                CreationDate = filteredModel.CreatedDate.ToString(),
                Branches = branchList
            };

            return View(filteredProcess);
        }

        [HttpGet("/ProcessDetails/Properties")]
        public IActionResult Properties()
        {
            string Id = Request.Query["ID"];
            _Data.SetDatabase(_Connection.GetDatabase());
            _Data.ReadFromDatabase(Id);
            return View(_Data.GetModel());
        }
    }
}