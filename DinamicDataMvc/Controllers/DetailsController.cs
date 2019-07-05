using System;
using System.Collections.Generic;
using System.Linq;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers
{
    public class DetailsController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IDetailsService _Details;
        private readonly IBranchService _Branch;
        private readonly IFieldService _Data;

        public DetailsController(IConnectionManagementService Connection, IDetailsService Details, IBranchService Branch, IFieldService Data)
        {
            _Connection = Connection;
            _Details = Details;
            _Branch = Branch;
            _Data = Data;
        }

        [HttpGet("/Details/ByName/{id}")]
        public IActionResult ByName(string id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            _Connection.DatabaseConnection();
            _Details.SetDatabase(_Connection.GetDatabase());
            _Branch.SetDatabase(_Connection.GetDatabase());

            _Details.ReadFromTable(id);
            List<MetadataModel> modelList = _Details.GetModels();
            List<ViewMetadataModel> viewModelList = new List<ViewMetadataModel>();

            ViewBag.Name = modelList[0].Name; //Stores the process name;

            foreach (var model in modelList)
            {
                _Branch.ReadFromDatabase(model.Branch);
                ViewMetadataModel _details = new ViewMetadataModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Version = model.Version.ToString(),
                    Date = model.Date.Day.ToString() + "/" + model.Date.Month.ToString() + "/" + model.Date.Year.ToString(),
                    Branch = _Branch.GetBranches(),
                    State = null,
                };
                viewModelList.Add(_details);
            }

            return View("ByName", viewModelList);
        }

        [HttpGet("/Details/ByVersion/{id}")]
        public IActionResult ByVersion(string id)
        {
            //Se o valor do identificador, for nulo ou vazio, o controlador devolve o status: BadRequest() --> error 400; 
            if (String.IsNullOrEmpty(id))
            {
                return BadRequest();
            }

            string name = Request.Query["Name"];
            ViewBag.Name = name;

            int versionNumber = Convert.ToInt32(id);


            _Connection.DatabaseConnection(); //Estabeleçe-se a conexão com a base de dados;
            var _database = _Connection.GetDatabase(); //Obtêm-se a base de dados pretendida para trabalhar as coleções de dados;
            _Details.SetDatabase(_database); //A base de dados em contexto é passada ao serviço;
            _Details.ReadFromTable(name); //Obtem-se da tabela Metadata 
            List<MetadataModel> models = _Details.GetModels(); //Armazena os modelos retornados que satisfaçam a condição ter um nome igual ao recebido

            MetadataModel filteredModel = null;
            foreach(var model in models)
            {
                if (model.Version == versionNumber) //seleciona o processo correspondente à versão pedida
                {
                    filteredModel = model;
                }
            }

            _Branch.SetDatabase(_database);
            _Branch.ReadFromDatabase(filteredModel.Branch);


            
            List<InputModel> FieldsList = new List<InputModel>();
           
            foreach(var itemId in filteredModel.Field)
            {
                _Data.SetDatabase(_database);
                _Data.ReadFromDatabase(itemId);
                var result = _Data.GetFieldCollection();

                InputModel model = new InputModel()
                {
                    Field = result.Field, 
                    Type = result.Type,
                    Name = result.Name,
                    Value = result.Value,
                    Required = result.Required,
                    MaxLength = result.MaxLength,
                    Size = result.Size
                };
                FieldsList.Add(model);
            }

            ViewBag.Data = FieldsList.AsEnumerable();

            ViewMetadataModel filteredProcess = new ViewMetadataModel()
            {
                Id = filteredModel.Id,
                Name = filteredModel.Name,
                Version = filteredModel.Version.ToString(),
                Date = filteredModel.Date.Day.ToString() + "/" + filteredModel.Date.Month.ToString() + "/" + filteredModel.Date.Year.ToString(),
                Branch = _Branch.GetBranches(),
                State = null
            };

            return View("ByVersion", filteredProcess);
        }

        [HttpPost("/Details/GetProperties")]
        public IActionResult GetProperties(InputModel model)
        {
            return View("Properties", model);
        }
    }
}