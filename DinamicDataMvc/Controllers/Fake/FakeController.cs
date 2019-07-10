using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using DinamicDataMvc.Utils;
using System.Threading.Tasks;

namespace DinamicDataMvc.Controllers.Fake
{
    /*
     * Contolador de Teste para testar individualmente os diversos serviços,
     * criados para tratar os pedidos dos utilizadores;
     */
    public class FakeController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IMetadataService _GetMetadata;
        private readonly IBranchService _GetBranchById;
        private readonly IStateService _GetStateById;

        public FakeController(IConnectionManagementService Connection, IMetadataService Metadata, IBranchService Branch, IStateService State)
        {
            _Connection = Connection;
            _GetMetadata = Metadata;
            _GetBranchById = Branch;
            _GetStateById = State;
        }

        [HttpGet("/Fake/TestDatabaseConnection/")]
        public string TestDatabaseConnection()
        {
            _Connection.DatabaseConnection();
            IMongoDatabase database = _Connection.GetDatabase();

            return "Your work database name is: " + database.DatabaseNamespace.DatabaseName;
        }


        [HttpGet("/Fake/TestState/")]
        public string TestState()
        {
            _Connection.DatabaseConnection();
            _GetStateById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.ReadFromDatabase("5ceac39b5cef382144c73570");


            return _GetStateById.GetStateDescription();
        }

        //[HttpGet("/Fake/TestBranchList/")]
        //public string TestBranchList()
        //{
        //    _Connection.DatabaseConnection();
        //    _GetBranchById.SetDatabase(_Connection.GetDatabase());
        //    _GetBranchById.ReadFromDatabase("5ce95b7970eb31116c6ca8d7");
        //    return _GetBranchById.GetBranches();
        //}

        //[HttpGet("/Fake/ProcessDetails/{id}")]
        //public IActionResult ProcessDetails(string id)
        //{
        //    return Redirect("~/ProcessDetails/Details/" + id);
        //}


        [HttpPost("/Fake/Confirm/{id}")]
        public async Task<ActionResult> Confirm(string id)
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
            catch (Exception exception)
            {
                throw new KeyNotFoundException(exception.Message);
            }
            return await Task.Run(() => RedirectToAction("ProcessList", "Fake"));
        }


        [HttpPost("/Fake/Delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                if (id != null)
                {
                    _Connection.DatabaseConnection();
                    _GetMetadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;
                    _GetBranchById.SetDatabase(_Connection.GetDatabase());
                    _GetStateById.SetDatabase(_Connection.GetDatabase());
                    _GetMetadata.ReadFromDatabase();
                    MetadataModel model = _GetMetadata.GetMetadata(id);

                    _GetBranchById.ReadFromDatabase(model.Branch);
                    _GetStateById.ReadFromDatabase(model.State);

                    ViewMetadataModel ModelToDelete = new ViewMetadataModel()
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Version = model.Version.ToString(),
                        Date = model.Date.ToString(),
                        Branch = _GetBranchById.GetBranches(),
                        State = _GetStateById.GetStateDescription()
                    };

                    return await Task.Run(() => View("Delete", ModelToDelete));
                }
                return await Task.Run(() => View("Delete"));
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        [HttpGet("/Fake/Read")]
        public async Task<ActionResult> Read()
        {
            //Stores data in cache;
            TempData["Name"] = Request.Query["Name"];
            string searchName = TempData["Name"].ToString();
            ViewBag.Name = searchName;

            TempData["Version"] = Request.Query["Version"];
            string searchVersion = TempData["Version"].ToString();
            ViewBag.Version = searchVersion;

            TempData["PageNumber"] = Request.Query["PageNumber"];
            string pageNumber = TempData["PageNumber"].ToString();

            if (string.IsNullOrEmpty(pageNumber))
            {
                pageNumber = "1";
            }

            int pageIndex = Convert.ToInt32(pageNumber);

            if (string.IsNullOrEmpty(searchName))
            {
                searchName = null;
            }
            //No caso de a string que representa a informação do filtro de pesquisa por versão, ser nula ou vazia,
            //define-se como valor default a versão 1;
            if (string.IsNullOrEmpty(searchVersion))
            {
                searchVersion = "0";
            }

            ViewBag.PageNumber = pageIndex.ToString();

            _Connection.DatabaseConnection();
            _GetMetadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;
            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.SetDatabase(_Connection.GetDatabase());

            _GetMetadata.SetFilterParameters(searchName, Convert.ToInt32(searchVersion));
            _GetMetadata.ReadFromDatabase();
            

            List<MetadataModel> metadataList = _GetMetadata.GetProcessesMetadataList();
            List<ViewMetadataModel> viewModels = new List<ViewMetadataModel>();

            foreach (var metadata in metadataList)
            {
                _GetBranchById.ReadFromDatabase(metadata.Branch);
                _GetStateById.ReadFromDatabase(metadata.State);

                ViewMetadataModel viewModel = new ViewMetadataModel()
                {
                    Id = metadata.Id,
                    Name = metadata.Name,
                    Version = metadata.Version.ToString(),
                    Date = metadata.Date.ToString(),
                    Branch = _GetBranchById.GetBranches(),
                    State = _GetStateById.GetStateDescription()
                };

                viewModels.Add(viewModel);
            }
            int pageSize = 3;

            PaginatedList ModelsToDisplay = new PaginatedList(viewModels, pageIndex, pageSize);

            ViewBag.TotalPages = ModelsToDisplay.TotalPages;

            return await Task.Run(() => View("Read", ModelsToDisplay.GetModelsList(pageIndex)));
        }

        [HttpGet("/Fake/Details/")]
        public async Task<ActionResult> DetailsByName(string name)
        {
            return await Task.Run(() => View());
        }
    }
}