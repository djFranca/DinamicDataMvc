using System;
using System.Collections.Generic;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers
{
    public class ProcessMetadataController : Controller
    {
        private readonly IConnectionManagement _Connection;
        private readonly IGetProcessesMetadata _GetMetadata;
        private readonly IGetBranchById _GetBranchById;
        private readonly IGetStateById _GetStateById;

        public ProcessMetadataController(IConnectionManagement Connection, IGetProcessesMetadata GetMetadata, IGetBranchById GetBranchById, IGetStateById GetStateById)
        {
            _Connection = Connection;
            _GetMetadata = GetMetadata;
            _GetBranchById = GetBranchById;
            _GetStateById = GetStateById;
        }

        [HttpGet("/ProcessMetadata/GetProcessesMetadata")]
        public IActionResult GetProcessesMetadata()
        {
            string name = null;
            int version = 0;

            //Verificações dos parâmetros recebidos no URL do pedido (nome e versão) do processo (Metadata)
            if (!Request.Query["SearchVersion"].Equals(""))
            {
                version = Convert.ToInt32(Request.Query["SearchVersion"]);
            }

            if (!Request.Query["SearchName"].Equals(""))
            {
                name = Request.Query["SearchName"];
            }

            List<MetadataListModel> ListModel = new List<MetadataListModel>();

            _Connection.DatabaseConnection();
            _GetMetadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;

            _GetMetadata.SetFilterParameters(name, version); //Definem-se parâmetros de filtragem de informação
            _GetMetadata.ReadFromDatababe(); //Procede-se à leitura da base de dados;

            List<MetadataModel> Model = _GetMetadata.GetProcessesMetadataList();

            foreach (var item in Model)
            {
                List<string> Branch = new List<string>();

                string Name = item.Name;
                string Version = "V" + item.Version.ToString();
                string Date = item.CreatedDate.ToShortDateString();

                _GetBranchById.SetDatabase(_Connection.GetDatabase());

                foreach (var id in item.Branch)
                {
                    _GetBranchById.ReadFromDatabase(id);
                    var branch = _GetBranchById.GetBranches();
                    Branch.Add(branch);
                }

                _GetStateById.SetDatabase(_Connection.GetDatabase());
                _GetStateById.ReadFromDatabase(item.State);
                string State = _GetStateById.GetStateDescription();

                MetadataListModel _model = new MetadataListModel()
                {
                    Name = Name,
                    Version = Version,
                    Date = Date,
                    Branch = Branch,
                    State = State
                };
                ListModel.Add(_model);
            }
            return View(ListModel);
        }

        [HttpGet("/ProcessMetadata/ProcessDetails/{id}")]
        public IActionResult ProcessDetails(string id)
        {
            return Redirect("~/ProcessDetails/Details/" + id);
        }
    }
}