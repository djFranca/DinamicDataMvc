﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Metadata;
using DinamicDataMvc.Models.Field;
using DinamicDataMvc.Models.Process;
using Microsoft.AspNetCore.Mvc;
using DinamicDataMvc.Models.Properties;

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
        private readonly IProcessHistory _Log;

        public MetadataController(IConnectionManagementService Connection, IMetadataService GetMetadata, IBranchService GetBranchById, IStateService GetStateById, IFieldService GetFieldTypes, IPaginationService SetPagination, IKeyGenerates KeyID, IPropertyService Properties, IValidationService Validation, IProcessHistory Log)
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
            _Log = Log;
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
                searchVersion = null;
            }

            ViewBag.PageNumber = pageNumber;

            _Connection.DatabaseConnection();
            _Metadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;
            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.SetDatabase(_Connection.GetDatabase());

            _Metadata.SetFilterParameters(searchName, searchVersion);
            _Metadata.ReadFromDatabase();

            List<MetadataModel> metadataList = _Metadata.GetProcessesMetadataList();
            List<ViewMetadataModel> viewModels = new List<ViewMetadataModel>();

            if(metadataList != null)
            {
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
            }
            _SetPagination.SetNumberOfModelsByPage(4);
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

            //------------------------------------------
            //Add - Pagination to Page (Phase 1)
            //------------------------------------------
            string pageNumber = Request.Query["Page"];
            if (string.IsNullOrEmpty(pageNumber))
            {
                pageNumber = 1.ToString();
            }
            int pageIndex = Convert.ToInt32(pageNumber);
            ViewBag.PageNumber = pageNumber;
            //------------------------------------------

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
                    Date = model.Date.ToString(),
                    Branch = _GetBranchById.GetBranches(),
                    State = _GetStateById.GetStateDescription(),
                };
                _ViewModelList.Add(_details);
            }

            //------------------------------------------
            //Add - Pagination to Page (Phase 2)
            //------------------------------------------
            _SetPagination.SetNumberOfModelsByPage(2);
            Dictionary<int, List<ViewMetadataModel>> modelsToDisplay = _SetPagination.SetModelsByPage(_ViewModelList);
            int NumberOfPages = modelsToDisplay.Count();
            ViewBag.NumberOfPages = NumberOfPages;
            //------------------------------------------
            return await Task.Run(() => View("GetDetailsByName", modelsToDisplay[pageIndex]));
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

            //------------------------------------------
            //Add - Pagination to Page (Phase 1)
            //------------------------------------------
            string pageNumber = Request.Query["Page"];
            if (string.IsNullOrEmpty(pageNumber))
            {
                pageNumber = 1.ToString();
            }
            int pageIndex = Convert.ToInt32(pageNumber);
            ViewBag.PageNumber = pageNumber; //Passa para a view o número da página;
            ViewBag.Id = id; //Passa para a view o identificador do processo;
            //------------------------------------------

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

            //------------------------------------------
            //Add - Pagination to Page (Phase 2)
            //------------------------------------------
            _SetPagination.SetNumberOfModelsByPage(2);
            Dictionary<int, List<FieldModel>> fieldsToDisplay = _SetPagination.SetModelsByPage(fields);
            int NumberOfPages = fieldsToDisplay.Count();
            ViewBag.NumberOfPages = NumberOfPages;
            //------------------------------------------

            //5º Passo . construir o modelo que permite efetuar o dsiplay do processo seleccionado através da sua versão;
            ViewProcessModel viewModel = new ViewProcessModel()
            {
                Metadata = metadata,
                Fields = fieldsToDisplay[pageIndex]
            };
            return await Task.Run(() => View("GetDetailsByVersion", viewModel));
        }


        [HttpPost("/Metadata/Delete/{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id != null)
            {
                _Connection.DatabaseConnection();
                _Metadata.SetDatabase(_Connection.GetDatabase()); //Estabeleçe a conexão;
                _GetBranchById.SetDatabase(_Connection.GetDatabase());
                _GetStateById.SetDatabase(_Connection.GetDatabase());
                //_Metadata.ReadFromDatabase();
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


        [HttpPost("/Metadata/Confirm/{id}")]
        public async Task<ActionResult> Confirm(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            _Connection.DatabaseConnection();
            _Metadata.SetDatabase(_Connection.GetDatabase());
            _Field.SetDatabase(_Connection.GetDatabase());
            _Properties.SetDatabase(_Connection.GetDatabase());
            _Log.SetDatabase(_Connection.GetDatabase());

            //Obter os ids dos campos anexos a um processo;
            List<string> fields = _Metadata.GetProcessFieldsID(id);

            foreach (var field in fields)
            {
                FieldModel fieldModel = _Field.GetField(field);
                //Obter os ids das propriedades de um campo pertencente a um processo;
                _Properties.DeleteProperties(fieldModel.Properties); //Apaga na base de dados as propriedades existentes num campo;
                _Field.DeleteField(field); //Apaga na base de dados os campos existentes num processo;
            }

            /* 
                * -------------------------------------------------------------------------------------
                * Log section
                * -------------------------------------------------------------------------------------
                */
            MetadataModel metadataModel = _Metadata.GetMetadata(id);
            _KeyID.SetKey(); //Generates a log model object id (unique key) 
            _Log.CreateProcessLog(_KeyID.GetKey(), id, metadataModel.Name, metadataModel.Version, "Delete");
            //--------------------------------------------------------------------------------------

            _Metadata.DeleteMetadata(id); //Apaga na base de dados o processo propriamente dito;

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
            if (viewModel == null)  //Se o modelo de dados estiver vazio, redirecciona para a mesma página;
            {
                return await Task.Run(() => RedirectToAction("Create", "Metadata"));
            }

            _Connection.DatabaseConnection();
            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.SetDatabase(_Connection.GetDatabase());
            _Metadata.SetDatabase(_Connection.GetDatabase());
            _Validation.SetDatabase(_Connection.GetDatabase());
            _Log.SetDatabase(_Connection.GetDatabase());

            if (_Validation.ProcessExits(viewModel.Name)) //Se o nome já existir na base de dados, redirecciona para a mesma página;
            {
                //Default message:
                string Message = "The process Name already exists in database. \n" +
                    "Insert a diferent Name.";

                //Alert Message:
                TempData["AlertMessage"] = Message;

                //Redirect to create page:
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

            /* 
             * -------------------------------------------------------------------------------------
             * Log section
             * -------------------------------------------------------------------------------------
             */
            _KeyID.SetKey(); //Generates a log model object id (unique key) 
            _Log.CreateProcessLog(_KeyID.GetKey(), model.Id, model.Name, 1, "Create");
            //--------------------------------------------------------------------------------------

            _Metadata.CreateMetadata(model);
            //return await Task.Run(() => RedirectToAction("Display", "Field", new { ID = modelId }));
            return await Task.Run(() => RedirectToAction("Read", "Field", new { ProcessId = modelId } ));
        }


        [HttpGet("/Metadata/Update")]
        public async Task<ActionResult> Update()
        {
            string processName = Request.Query["ProcessName"];

            if (string.IsNullOrEmpty(processName))
            {
                return BadRequest();
            }

            _Connection.DatabaseConnection(); //Estabeleçe a ligação / conexão com a base de dados;
            _KeyID.SetKey(); //Cria um novo objectId para identificar univocamente o processo na base de dados;
            _Metadata.SetDatabase(_Connection.GetDatabase()); //Cria uma instância da base de dados no serviço de Metadados;
            _Validation.SetDatabase(_Connection.GetDatabase()); //Cria uma instância da base de dados no serviço de validação;
            _GetStateById.SetDatabase(_Connection.GetDatabase());
            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            

            //1º Passo - Obter a última versão deste processo
            int lastVersion = _Validation.GetProcessLastVersion(processName);

            //2º Passo - Obter o processo anterior ao momento em que sofre uma atualização
            MetadataModel model = _Metadata.GetProcessByVersion(processName, lastVersion);

            _GetBranchById.ReadFromDatabase(model.Branch);

            //3º Passo - Construir o modelo de dados View Metadata Model
            ViewMetadataModel modelToDisplay = new ViewMetadataModel()
            {
                Id = _KeyID.GetKey(), //4º Passo - Atualizar o ID do processo, pois trata-se de um processo independente;
                Name = model.Name,
                Version = (model.Version += 1).ToString(), //5º Passo - Atualizar a versão do processo, para uma versão superior incrementando o número da mesma;
                Date = DateTime.Now.ToString().Substring(0, 10),
                State = _GetStateById.GetStateDescription(),
                Branch = _GetBranchById.GetBranches(),
            };

            string fields = string.Empty;

            //6º Passo - Obter os ids dos fields agregados ao processo
            for (int j = 0; j < model.Field.Count(); j++){
                if(j == model.Field.Count() - 1)
                {
                    fields += model.Field.ElementAt(j);
                }
                else
                {
                    fields += (model.Field.ElementAt(j) + ";");
                }
            }

            ViewBag.Fields = fields;

            return await Task.Run(() => View("Update", modelToDisplay));
        }


        [HttpPost("/Metadata/UpdateProcess")]
        public async Task<ActionResult> UpdateProcess(MetadataModel viewModel)
        {
            if(viewModel == null) //Se o modelo de dados estiver vazio, redirecciona para a mesma página;
            {
                return await Task.Run(() => RedirectToAction("Update", "Metadata"));
            }

            _Connection.DatabaseConnection();
            _Field.SetDatabase(_Connection.GetDatabase());
            _Metadata.SetDatabase(_Connection.GetDatabase());
            _GetBranchById.SetDatabase(_Connection.GetDatabase());
            _GetStateById.SetDatabase(_Connection.GetDatabase());
            _Properties.SetDatabase(_Connection.GetDatabase());
            _Log.SetDatabase(_Connection.GetDatabase());

            //1º Passo - Obter os objetos FieldModel e PropertiesModel agregados à versão anterior e passados no Modelo de dados MetadataModel;
            //-----------------------------------------------------
            //Sistema independente - Utils
            //-----------------------------------------------------
            List<string> fieldIdKeys = new List<string>(); //Armazena a lista de novos ids dos campos do processo atualizado;
            List<FieldModel> fieldClones = new List<FieldModel>(); //Armazena os campos clonados da versão anterior
            foreach (var field in viewModel.Field)
            {
                FieldModel model = _Field.GetField(field);
                fieldClones.Add(model);
            }

            foreach (var fieldCloned in fieldClones)
            {
                PropertiesModel model = _Properties.GetProperties(fieldCloned.Properties);
                _KeyID.SetKey(); //Gera um novo object id para criar uma nova coleção na tabela de propriedades;
                model.ID = _KeyID.GetKey(); //Afecta o novo identificador object id ao modelo de dados properties;
                _Properties.CreateProperties(model); //cria um novo modelo de dados do tipo propriedades;
                fieldCloned.Properties = model.ID; //Afecta o id dessas propriedades criadas ao campo do novo processo

                _KeyID.SetKey(); //Gera um novo object id para criar uma nova coleção na tabela de campos;
                fieldCloned.Id = _KeyID.GetKey(); //Afecta o novo identificador object id ao modelo de dados properties;
                fieldIdKeys.Add(fieldCloned.Id); //Armazena na lista de novas keys referentes aos campos clonados o id do campo clonado;
                _Field.CreateField(fieldCloned); //cria um novo modelo de dados do tipo campos;
            }
            //-----------------------------------------------------

            //2º Passo - obter a designação dos branches em que se encontra o processo;
            List<string> branches = new List<string>();
            foreach (var branch in viewModel.Branch)
            {
                branches.Add(_GetBranchById.GetBranchID(branch));
            }

            //3º Passo - Cria e armazena na base de dados uma nova versão do processo atualizado;
            MetadataModel UpdatedMetadataModel = new MetadataModel()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Version = viewModel.Version,
                Date = Convert.ToDateTime(viewModel.Date),
                State = _GetStateById.GetStateID(viewModel.State),
                Field = fieldIdKeys,
                Branch = branches
            };

            /* 
             * -------------------------------------------------------------------------------------
             * Log section
             * -------------------------------------------------------------------------------------
             */
            _KeyID.SetKey(); //Generates a log model object id (unique key) 
            _Log.CreateProcessLog(_KeyID.GetKey(), viewModel.Id, viewModel.Name, viewModel.Version, "Update");
            //--------------------------------------------------------------------------------------

            _Metadata.CreateMetadata(UpdatedMetadataModel); //armazena o processo na base de dados;

            return await Task.Run(() => RedirectToAction("Read", "Field", new { ProcessId = viewModel.Id }));
        }


        /*
         * Selecionar o branch que se pretende operar;
         */
        [HttpPost("/Metadata/SelectBranch")]
        public async Task<ActionResult> SelectBranch(string processId, string processName, string processVersion, string processDate, string processBranches, string processState, string isReadonly)
        {
            ViewMetadataModel viewModel = new ViewMetadataModel()
            {
                Id = processId,
                Name = processName,
                Version = processVersion,
                Date = processDate,
                Branch = processBranches,
                State = processState
            };

            ViewBag.IsReadonly = isReadonly;

            return await Task.Run(() => View("SelectBranch", viewModel));
        }
    }
}