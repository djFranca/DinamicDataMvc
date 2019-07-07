using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using PagedList.Core;
using System.Linq;
using DinamicDataMvc.Utils;
using System.Threading.Tasks;

namespace DinamicDataMvc.Tests
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



        [HttpGet("/Fake/Test")]
        public IActionResult Test(int page = 1, int pageSize = 1)
        {
            //string name = null;
            //int version = 0;


            //Verificações dos parâmetros recebidos no URL do pedido (nome e versão) do processo (Metadata)
            //if (!Request.Query["SearchVersion"].Equals(""))
            //{
            //    version = Convert.ToInt32(Request.Query["SearchVersion"]);
            //}

            //if (!Request.Query["SearchName"].Equals("")) {
            //    name = Request.Query["SearchName"];
            //}

            //List<MetadataListModel> ListModel = new List<MetadataListModel>();

            _Connection.DatabaseConnection();
            _GetMetadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;
            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.SetDatabase(_Connection.GetDatabase());

            //_GetMetadata.SetFilterParameters(name, version); //Definem-se parâmetros de filtragem de informação

            _GetMetadata.ReadFromDatabase(); //Procede-se à leitura da base de dados;
           
            //List<MetadataModel> Model = _GetMetadata.GetProcessesMetadataList();

            //IQueryable<MetadataModel> model = _GetMetadata.GetMetadata().AsQueryable();

            //PagedList<MetadataModel> newModel = new PagedList<MetadataModel>(model, page, pageSize);

            List<MetadataModel> metadataList = _GetMetadata.GetProcessesMetadataList();
            List<ViewMetadataModel> viewModels = new List<ViewMetadataModel>();

            foreach(var metadata in metadataList)
            {
                _GetBranchById.ReadFromDatabase(metadata.Branch);
                _GetStateById.ReadFromDatabase(metadata.State);

                ViewMetadataModel viewModel = new ViewMetadataModel()
                {
                    Name = metadata.Name,
                    Version = metadata.Version.ToString(),
                    Date = null,
                    Branch = _GetBranchById.GetBranches(),
                    State = _GetStateById.GetStateDescription()
                };

                viewModels.Add(viewModel);
            }

            PagedList<ViewMetadataModel> newModel = new PagedList<ViewMetadataModel>(viewModels.AsQueryable(), page, pageSize);

            //foreach (var item in Model)
            //{
            //    List<string> Branch = new List<string>();

            //    string Name = item.Name;
            //    string Version = "V" + item.Version.ToString();
            //    string Date = item.CreatedDate.ToShortDateString();

            //    _GetBranchById.SetDatabase(_Connection.GetDatabase());

            //    foreach (var id in item.Branch)
            //    {
            //        _GetBranchById.ReadFromDatabase(id);
            //        var branch = _GetBranchById.GetBranches();
            //        Branch.Add(branch);
            //    }

            //    _GetStateById.SetDatabase(_Connection.GetDatabase());
            //    _GetStateById.ReadFromDatabase(item.State);
            //    string State = _GetStateById.GetStateDescription();

            //    MetadataListModel _model = new MetadataListModel()
            //    {
            //        Name = Name,
            //        Version = Version,
            //        Date = Date,
            //        Branch = Branch,
            //        State = State
            //    };
            //    ListModel.Add(_model);

            //}

            return View("Test", newModel);
        }



        //[HttpGet("/Fake/TestBranchList/")]
        //public string TestBranchList()
        //{
        //    _Connection.DatabaseConnection();
        //    _GetBranchById.SetDatabase(_Connection.GetDatabase());
        //    _GetBranchById.ReadFromDatabase("5ce95b7970eb31116c6ca8d7");
        //    return _GetBranchById.GetBranches();
        //}

        [HttpGet("/Fake/TestState/")]
        public string TestState()
        {
            _Connection.DatabaseConnection();
            _GetStateById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.ReadFromDatabase("5ceac39b5cef382144c73570");


            return _GetStateById.GetStateDescription();
        }

        //[HttpGet("/Fake/ProcessDetails/{id}")]
        //public IActionResult ProcessDetails(string id)
        //{
        //    return Redirect("~/ProcessDetails/Details/" + id);
        //}

        [HttpPost("/Fale/Delete/{id}")]
        public async Task<ActionResult> Delete(string id)
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



        [HttpGet("/Fake/ProcessList")]
        public async Task<ActionResult> ProcessList()
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

            return await Task.Run(() => View("ProcessList", ModelsToDisplay.GetModelsList(pageIndex)));
        }
    }
}