using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Utils;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers.Metadata
{
    public class MetadataController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IMetadataService _GetMetadata;
        private readonly IBranchService _GetBranchById;
        private readonly IStateService _GetStateById;
        private readonly IFieldService _GetFieldTypes;

        public MetadataController(IConnectionManagementService Connection, IMetadataService GetMetadata, IBranchService GetBranchById, IStateService GetStateById, IFieldService GetFieldTypes)
        {
            _Connection = Connection;
            _GetMetadata = GetMetadata;
            _GetBranchById = GetBranchById;
            _GetStateById = GetStateById;
            _GetFieldTypes = GetFieldTypes;
        }

        [HttpGet("/Metadata/Read")]
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


        [HttpGet("/Metadata/GetDetailsByName")]
        public async Task<ActionResult> GetDetailsByName(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            _Connection.DatabaseConnection();
            _GetMetadata.SetDatabase(_Connection.GetDatabase());
            _GetBranchById.SetDatabase(_Connection.GetDatabase());

            
            List<MetadataModel> modelList = _GetMetadata.GetProcessByName(id);
            List<ViewMetadataModel> _ViewModelList = new List<ViewMetadataModel>();

            ViewBag.Name = modelList[0].Name; //Stores the process name;

            foreach (var model in modelList)
            {
                _GetBranchById.ReadFromDatabase(model.Branch);
                ViewMetadataModel _details = new ViewMetadataModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Version = model.Version.ToString(),
                    Date = model.Date.Day.ToString() + "/" + model.Date.Month.ToString() + "/" + model.Date.Year.ToString(),
                    Branch = _GetBranchById.GetBranches(),
                    State = null,
                };
                _ViewModelList.Add(_details);
            }

            return await Task.Run(() => View("GetDetailsByName", _ViewModelList));
        }


        [HttpGet("/Metadata/GetDetailsByVersion")]
        public async Task<ActionResult> GetDetailsByVersion(string name, string version)
        {
            int versionNumber = Convert.ToInt32(version);

            if (string.IsNullOrEmpty(name) & versionNumber < 1)
            {
                return BadRequest();
            }

            _Connection.DatabaseConnection(); //Estabeleçe-se a conexão com a base de dados;
            _GetMetadata.SetDatabase(_Connection.GetDatabase());
            MetadataModel _model = _GetMetadata.GetProcessByVersion(name, versionNumber);

            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetBranchById.ReadFromDatabase(_model.Branch);

            _GetStateById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.ReadFromDatabase(_model.State);

            ViewMetadataModel _ViewMetadataModel = new ViewMetadataModel()
            {
                Id = _model.Id,
                Name = _model.Name,
                Version = _model.Version.ToString(),
                Date = _model.Date.Day.ToString() + "/" + _model.Date.Month.ToString() + "/" + _model.Date.Year.ToString(),
                Branch = _GetBranchById.GetBranches(),
                State = _GetStateById.GetStateDescription()
            };

            return await Task.Run(() => View("GetDetailsByVersion", _ViewMetadataModel));
        }


        [HttpPost("/Metadata/Delete/{id}")]
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

        [HttpPost("/Metadata/Confirm/{id}")]
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
            return await Task.Run(() => RedirectToAction("Read", "Metadata"));
        }

        [HttpGet("/Metadata/CreateProcess/")]
        public async Task<ActionResult> CreateProcess()
        {
            return await Task.Run(() => View("Create"));
        }

        [HttpPost("/Metadata/AddProcess/")]
        public string AddProcess(ViewMetadataModel model)
        {


            return model.Name + ", " + model.Version;
        }

        [HttpGet]
        public async Task<ActionResult> AddFields()
        {
            _Connection.DatabaseConnection();
            _GetFieldTypes.SetDatabase(_Connection.GetDatabase());
            List<string> types = _GetFieldTypes.GetFieldType();

            return await Task.Run(() => View("AddFields", types));
        }
    }
}