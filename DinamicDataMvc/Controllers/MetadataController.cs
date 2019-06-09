using System;
using System.Collections.Generic;
using System.Linq;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace DinamicDataMvc.Controllers
{
    public class MetadataController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IMetadataService _GetMetadata;
        private readonly IBranchService _GetBranchById;
        private readonly IStateService _GetStateById;

        public MetadataController(IConnectionManagementService Connection, IMetadataService GetMetadata, IBranchService GetBranchById, IStateService GetStateById)
        {
            _Connection = Connection;
            _GetMetadata = GetMetadata;
            _GetBranchById = GetBranchById;
            _GetStateById = GetStateById;
        }

        [HttpGet("/Metadata/GetMetadata")]
        public IActionResult GetMetadata(int? page)
        {
            string name = null;
            int version = 0;
            int pageSize = 2;

            int? pageNumber = page == null || page <= 0 ? 1 : page;

            //Verificações dos parâmetros recebidos no URL do pedido (nome e versão) do processo (Metadata)
            if (!String.IsNullOrEmpty(Request.Query["SearchVersion"]))
            {
                version = Convert.ToInt32(Request.Query["SearchVersion"]);
            }

            if (!String.IsNullOrEmpty(Request.Query["SearchName"]))
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
                    Id = model.Id,
                    Name = model.Name,
                    Version = model.Version.ToString(),
                    Date = model.Date,
                    Branch = _GetBranchById.GetBranches(),
                    State = _GetStateById.GetStateDescription()
                };
                ListModel.Add(_model);
            }
            PagedList<ViewMetadataModel> newModel = new PagedList<ViewMetadataModel>(ListModel.AsQueryable(), Convert.ToInt32(pageNumber), pageSize);
            return View("GetMetadata", newModel);
        }

        [HttpGet("/Metadata/GetDetails/{id}")]
        public IActionResult GetDetails(string id)
        {
            return Redirect("~/ProcessDetails/Details/" + id);
        }

        [HttpGet("/Metadata/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var _model = _GetMetadata.GetModel(id);

                if (_model == null)
                {
                    return NotFound();
                }
                _GetStateById.SetDatabase(_Connection.GetDatabase());
                _GetStateById.ReadFromDatabase(_model.State);
                ViewBag.State = _GetStateById.GetStateDescription();

                return View("Delete", _model);
            }
            catch
            {
                throw new KeyNotFoundException();
            }
        }

        [HttpPost("/Metadata/ConfirmDelete")]
        public IActionResult ConfirmDelete(string id)
        {
            try
            {
                if (id != null)
                {
                    _Connection.DatabaseConnection();
                    _GetMetadata.SetDatabase(_Connection.GetDatabase());
                    _GetMetadata.DeleteMetadata(id);
                }
            }
            catch(Exception exception)
            {
                throw new KeyNotFoundException(exception.Message);
            }

            return Redirect("~/Metadata/GetMetadata");
        }
    }
}