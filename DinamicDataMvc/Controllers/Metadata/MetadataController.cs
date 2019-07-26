using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Models.Field;
using DinamicDataMvc.Models.Process;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers.Metadata
{
    public class MetadataController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IMetadataService _Metadata;
        private readonly IBranchService _GetBranchById;
        private readonly IStateService _GetStateById;
        private readonly IFieldService _Field;
        private readonly IPaginationService _SetPagination;
        private readonly IKeyGenerates _KeyID;
        private readonly IPropertyService _Properties;
        private readonly IValidationService _Validation;

        public MetadataController(IConnectionManagementService Connection, IMetadataService GetMetadata, IBranchService GetBranchById, IStateService GetStateById, IFieldService GetFieldTypes, IPaginationService SetPagination, IKeyGenerates KeyID, IPropertyService Properties, IValidationService Validation)
        {
            _Connection = Connection;
            _Metadata = GetMetadata;
            _GetBranchById = GetBranchById;
            _GetStateById = GetStateById;
            _Field = GetFieldTypes;
            _SetPagination = SetPagination;
            _KeyID = KeyID;
            _Properties = Properties;
            _Validation = Validation;
        }

        /*
         * Read Action - Implementa a lista de Processos ao nivel dos seus Metadados;
         */
        [HttpGet("/Metadata/Read/")]
        public async Task<ActionResult> Read()
        {
            //Stores data in cache;
            TempData["Name"] = Request.Query["Name"];
            string searchName = TempData["Name"].ToString();
            ViewBag.Name = searchName;

            TempData["Version"] = Request.Query["Version"];
            string searchVersion = TempData["Version"].ToString();
            ViewBag.Version = searchVersion;

            string pageNumber = Request.Query["Page"];
            

            if (string.IsNullOrEmpty(pageNumber))
            {
                pageNumber = 1.ToString();
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

            ViewBag.PageNumber = pageNumber;

            _Connection.DatabaseConnection();
            _Metadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;
            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.SetDatabase(_Connection.GetDatabase());

            _Metadata.SetFilterParameters(searchName, Convert.ToInt32(searchVersion));
            _Metadata.ReadFromDatabase();


            List<MetadataModel> metadataList = _Metadata.GetProcessesMetadataList();
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
            Dictionary<int, List<ViewMetadataModel>> modelsToDisplay = _SetPagination.SetModelsByPage(viewModels);

            int NumberOfPages = modelsToDisplay.Count();
            ViewBag.NumberOfPages = NumberOfPages;


            //Se a base de dados não tiver processos armazenados para mostrar na listagem de processos;
            if(modelsToDisplay.Count() == 0)
            {
                List<ViewMetadataModel> models = new List<ViewMetadataModel>();
                ViewMetadataModel model = new ViewMetadataModel()
                {
                    Id = string.Empty,
                    Name = string.Empty,
                    Version = string.Empty,
                    Date = string.Empty,
                    Branch = string.Empty,
                    State = string.Empty
                };
                models.Add(model);
                return await Task.Run(() => View("Read", models));
            }

            return await Task.Run(() => View("Read", modelsToDisplay[pageIndex]));
        }


        [HttpGet("/Metadata/GetDetailsByName")]
        public async Task<ActionResult> GetDetailsByName(string name)
        {
            if (name == null)
            {
                return BadRequest();
            }
            _Connection.DatabaseConnection();
            _Metadata.SetDatabase(_Connection.GetDatabase());
            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.SetDatabase(_Connection.GetDatabase());

            List<MetadataModel> modelList = _Metadata.GetProcessByName(name);
            List<ViewMetadataModel> _ViewModelList = new List<ViewMetadataModel>();

            ViewBag.Name = modelList[0].Name; //Stores the process name;

            foreach (var model in modelList)
            {
                _GetBranchById.ReadFromDatabase(model.Branch);
                _GetStateById.ReadFromDatabase(model.State);
                ViewMetadataModel _details = new ViewMetadataModel()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Version = model.Version.ToString(),
                    Date = model.Date.ToString().Substring(0, 10),
                    Branch = _GetBranchById.GetBranches(),
                    State = _GetStateById.GetStateDescription(),
                };
                _ViewModelList.Add(_details);
            }

            return await Task.Run(() => View("GetDetailsByName", _ViewModelList));
        }



        [HttpGet("/Metadata/GetDetailsByVersion")]
        public async Task<ActionResult> GetDetailsByVersion(string id)
        {
            _Connection.DatabaseConnection(); //Estabeleçe-se a conexão com a base de dados;
            _Metadata.SetDatabase(_Connection.GetDatabase()); //Cria uma instância da base de dados no serviço;
            _Field.SetDatabase(_Connection.GetDatabase()); //Cria uma instância da base de dados no serviço;

            //Se o identificador não tiver qualquer valor armazenado, devolve um bad request;
            if(id == null)
            {
                return BadRequest();
            }
           
            //1º Passo - obter o MetadataModel;
            MetadataModel metadata = _Metadata.GetMetadata(id);

            //2ºPasso - Coverter o Id do estado para a sua descrição;
            _GetStateById.ReadFromDatabase(metadata.State); 
            ViewBag.State = _GetStateById.GetStateDescription();

            //3ºPasso - Agregar oas descrições dos branches ao qual o processo pertence numa string;
            _GetBranchById.ReadFromDatabase(metadata.Branch);
            ViewBag.Branches = _GetBranchById.GetBranches();

            //4º Passo - obter o(s) FieldModel(s);
            List<FieldModel> fields = new List<FieldModel>();

            foreach(var fieldId in metadata.Field)
            {
                FieldModel field = _Field.GetField(fieldId);
                fields.Add(field);
            }

            //5º Passo . construir o modelo que permite efetuar o dsiplay do processo seleccionado através da sua versão;
            ViewProcessModel modelToDisplay = new ViewProcessModel()
            {
                Metadata = metadata,
                Fields = fields
            };
            return await Task.Run(() => View("GetDetailsByVersion", modelToDisplay));
        }


        [HttpPost("/Metadata/Delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                if (id != null)
                {
                    _Connection.DatabaseConnection();
                    _Metadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;
                    _GetBranchById.SetDatabase(_Connection.GetDatabase());
                    _GetStateById.SetDatabase(_Connection.GetDatabase());
                    _Metadata.ReadFromDatabase();
                    MetadataModel model = _Metadata.GetMetadata(id);

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
                    _Metadata.SetDatabase(_Connection.GetDatabase());
                    _Field.SetDatabase(_Connection.GetDatabase());
                    _Properties.SetDatabase(_Connection.GetDatabase());

                    //Obter os ids dos campos anexos a um processo;
                    List<string> fields = _Metadata.GetProcessFieldsID(id);

                    foreach(var field in fields)
                    {
                        FieldModel fieldModel = _Field.GetField(field);
                        //Obter os ids das propriedades de um campo pertencente a um processo;
                        _Properties.Delete(fieldModel.Properties); //Apaga na base de dados as propriedades existentes num campo;
                        _Field.Delete(field); //Apaga na base de dados os campos existentes num processo;
                    }

                    _Metadata.DeleteMetadata(id); //Apaga na base de dados o processo propriamente dito;
                }
            }
            catch (Exception exception)
            {
                throw new KeyNotFoundException(exception.Message);
            }
            return await Task.Run(() => RedirectToAction("Read", "Metadata"));
        }

        [HttpGet("/Metadata/Create/")]
        public async Task<ActionResult> Create()
        {
            return await Task.Run(() => View("Create"));
        }

        [HttpPost("/Metadata/CreateProcess/")]
        public async Task<ActionResult> CreateProcess(MetadataModel viewModel)
        {
            try
            {
                if (viewModel == null)  //Se o modelo de dados estiver vazio, redirecciona para a mesma página;
                {
                    return await Task.Run(() => RedirectToAction("Create", "Metadata"));
                }

                _Connection.DatabaseConnection();

                _GetBranchById.SetDatabase(_Connection.GetDatabase());
                _GetStateById.SetDatabase(_Connection.GetDatabase());
                _Metadata.SetDatabase(_Connection.GetDatabase());
                _Validation.SetDatabase(_Connection.GetDatabase());

                if (_Validation.ProcessExits(viewModel.Name)) //Se o nome já existir na base de dados, redirecciona para a mesma página;
                {
                    return await Task.Run(() => RedirectToAction("Create", "Metadata"));
                }

                //Defines the properties model key
                _KeyID.SetKey(); //Sets a new properties ObjectID collection;
                string modelId = _KeyID.GetKey();

                List<string> branchList = new List<string>();

                foreach (var item in viewModel.Branch)
                {
                    branchList.Add(_GetBranchById.GetBranchID(item));
                }

                MetadataModel model = new MetadataModel()
                {
                    Id = modelId,
                    Name = viewModel.Name,
                    Version = Convert.ToInt32(viewModel.Version),
                    Date = Convert.ToDateTime(viewModel.Date),
                    State = _GetStateById.GetStateID(viewModel.State),
                    Field = new List<string>() { },
                    Branch = branchList
                };
                ViewBag.ID = viewModel.Id;
                _Metadata.CreateMetadata(model);
                return await Task.Run(() => RedirectToAction("Display", "Field", new { ID = modelId}));
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }
    }
}