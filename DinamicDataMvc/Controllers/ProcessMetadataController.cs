using System;
using System.Collections.Generic;
using System.Linq;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

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
        public IActionResult GetProcessesMetadata(int page = 1, int pageSize = 1)
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

            _Connection.DatabaseConnection();
            _GetMetadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;

            _GetMetadata.SetFilterParameters(name, version); //Definem-se parâmetros de filtragem de informação
            _GetMetadata.ReadFromDatababe(); //Procede-se à leitura da base de dados;

            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.SetDatabase(_Connection.GetDatabase());

            List<ViewMetadataModel> ListModel = new List<ViewMetadataModel>();
            List<MetadataModel> ListOfModels = _GetMetadata.GetProcessesMetadataList();

            foreach (var model in ListOfModels)
            {
                _GetBranchById.ReadFromDatabase(model.Branch);
                _GetStateById.ReadFromDatabase(model.State);

                ViewMetadataModel _model = new ViewMetadataModel()
                {
                    Name = model.Name,
                    Version = model.Version.ToString(),
                    Date = model.CreatedDate.ToShortDateString(),
                    Branch = _GetBranchById.GetBranches(),
                    State = _GetStateById.GetStateDescription()
                };
                ListModel.Add(_model);
            }

            PagedList<ViewMetadataModel> newModel = new PagedList<ViewMetadataModel>(ListModel.AsQueryable(), page, pageSize);
            return View(newModel);
        }

        [HttpGet("/ProcessMetadata/ProcessDetails/{id}")]
        public IActionResult ProcessDetails(string id)
        {
            return Redirect("~/ProcessDetails/Details/" + id);
        }
    }
}