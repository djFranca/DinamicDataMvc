using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Metadata;
using DinamicDataMvc.Models.Data;
using DinamicDataMvc.Models.Field;
using Microsoft.AspNetCore.Mvc;
using DinamicDataMvc.Models.Properties;
using DinamicDataMvc.Models.Tools;
using DinamicDataMvc.Utils;

namespace DinamicDataMvc.Controllers.Data
{
    public class DataController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IMetadataService _Metadata;
        private readonly IPaginationService _Pagination;
        private readonly IBranchService _Branch;
        private readonly IFieldService _Field;
        private readonly IPropertyService _Properties;
        private readonly IStateService _State;
        private readonly IDataService _Data;
        private readonly IKeyGenerates _KeyGenerates;
        private readonly IPaginationService _SetPagination;

        public DataController(IConnectionManagementService Connection, IMetadataService Metadata, IPaginationService Pagination, IBranchService Branch, IFieldService Field, IPropertyService Property, IStateService State, IDataService Data, IKeyGenerates KeyGenerates, IPaginationService SetPagination)
        {
            _Connection = Connection;
            _Metadata = Metadata;
            _Pagination = Pagination;
            _Branch = Branch;
            _Field = Field;
            _Properties = Property;
            _State = State;
            _Data = Data;
            _KeyGenerates = KeyGenerates;
            _SetPagination = SetPagination;
        }

        [HttpGet("/Data/GetLastProcessVersions/")]
        public async Task<ActionResult> GetLastProcessVersions()
        {
            //Stores data in cache;
            TempData["Name"] = Request.Query["Name"];
            string searchName = TempData["Name"].ToString();
            ViewBag.Name = searchName;

            TempData["Version"] = Request.Query["Version"];
            string searchVersion = TempData["Version"].ToString();
            ViewBag.Version = searchVersion;

            if (string.IsNullOrEmpty(searchName))
            {
                searchName = null;
            }

            //No caso de a string que representa a informação do filtro de pesquisa por versão, ser nula ou vazia,
            if (string.IsNullOrEmpty(searchVersion))
            {
                searchVersion = null;
            }

            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();
            _Metadata.SetDatabase(database);
            _Branch.SetDatabase(database);
            _State.SetDatabase(database);

            _Metadata.SetFilterParameters(searchName, searchVersion);
            _Metadata.ReadFromDatabase();

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
            //------------------------------------------

            //------------------------------------------
            //Obter as últimas versões dos processos
            //------------------------------------------
            string resultBranch = string.Empty;
            string resultState = string.Empty;

            List<MetadataModel> metadataList = _Metadata.GetProcessesMetadataList();

            if (metadataList != null)
            {
                foreach (var model in metadataList)
                {
                    _Branch.ReadFromDatabase(model.Branch);
                    resultBranch += (_Branch.GetBranches() + "|");

                    _State.ReadFromDatabase(model.State);
                    resultState += (_State.GetStateDescription() + "|");
                }
            }

            //------------------------------------------
            ViewBag.BranchesByProcess = resultBranch; //Armazena as descrições dos branches por processo;
            ViewBag.StatesByProcess = resultState; //Armazena as descrições dos estados por processo;

            //------------------------------------------
            //Add - Pagination to Page (Phase 2)
            //------------------------------------------
            Dictionary<int, List<MetadataModel>> modelsToDisplay = _Pagination.SetModelsByPage(metadataList);
            int NumberOfPages = modelsToDisplay.Count();
            ViewBag.NumberOfPages = NumberOfPages;
            //------------------------------------------

            //Se a base de dados não tiver processos armazenados para mostrar na listagem de processos;
            if (modelsToDisplay.Count() == 0)
            {
                List<MetadataModel> models = new List<MetadataModel>();
                MetadataModel model = new MetadataModel()
                {
                    Id = string.Empty,
                    Name = string.Empty,
                    Version = 0,
                    Date = DateTime.Now.ToLocalTime(),
                    Branch = new List<string>(),
                    Field = new List<string>(),
                    State = string.Empty
                };
                models.Add(model);
                return await Task.Run(() => View("GetLastProcessVersions", models));
            }

            return await Task.Run(() => View("GetLastProcessVersions", modelsToDisplay[pageIndex]));
        }

        [HttpGet("/Data/GetProcessFieldDataByVersions/")]
        public async Task<ActionResult> GetProcessFieldDataByVersions(string name, string version)
        {
            _Connection.DatabaseConnection(); //Estabeleçer a ligação com a base de dados;
            var database = _Connection.GetDatabase(); //Obter a ligação com a base de dados;
            _Metadata.SetDatabase(database);
            _Data.SetDatabase(database);

            /*
             * Paginação - Fase de obtenção do nº de página;
             */
            string pageNumber = Request.Query["Page"];

            if (string.IsNullOrEmpty(pageNumber))
            {
                pageNumber = 1.ToString();
            }

            int pageIndex = Convert.ToInt32(pageNumber);

            ViewBag.ProcessName = name;
            ViewBag.ProcessVersion = version;
            ViewBag.PageNumber = pageNumber;

            List<string> processIdList = new List<string>(); //Armazena a lista de id´s do processo nas diferentes versões;
            List<int> processVersionList = new List<int>(); //Armazena as versões correspondentes ao id do processo;

            //Recupera versões anteriores do processo se as mesmas existirem;
            if (int.Parse(version) >= 1)
            {
                for(int j = int.Parse(version); j >= 1; j--)
                {
                    processIdList.Add(_Metadata.GetProcessByVersion(name, j).Id);
                    processVersionList.Add(j);
                }
            }

            List<ViewDataModel> viewDataModelList = new List<ViewDataModel>(); //Lista de ViewDataModels, para display da dados;

            //Ciclo que percorre as diferentes combinações de {Process Id - Version - Branch}
            for (int i = 0; i < processIdList.Count; i++)
            {
                List<DataModel> dataModelList = _Data.GetDataModelByProcessId(processIdList.ElementAt(i));

                foreach(var dataModel in dataModelList)
                {
                    //É criado o modelo de dados do tipo ViewDataModel;
                    ViewDataModel modelToDisplay = new ViewDataModel()
                    {
                        ObjectId = _Data.GetObjectId(processIdList.ElementAt(i), processVersionList.ElementAt(i), dataModel.ProcessBranch, dataModel.Data),
                        ProcessId = processIdList.ElementAt(i),
                        ProcessVersion = processVersionList.ElementAt(i),
                        ProcessBranch = dataModel.ProcessBranch,
                        CreationDate = dataModel.Date,
                        Data = dataModel.Data
                    };
                    viewDataModelList.Add(modelToDisplay); //Adiciona-se à lista de ViewDataModel o modelo criado;
                }
            }
            _SetPagination.SetNumberOfModelsByPage(4);
            Dictionary<int, List<ViewDataModel>> modelsToDisplay = _SetPagination.SetModelsByPage(viewDataModelList);

            int NumberOfPages = modelsToDisplay.Count();
            ViewBag.NumberOfPages = NumberOfPages;

            if(modelsToDisplay.Count == 0)
            {
                List<ViewDataModel> auxViewDataModelList = new List<ViewDataModel>();
                ViewDataModel emptyModel = new ViewDataModel()
                {
                    ObjectId = null,
                    ProcessId = null,
                    ProcessVersion = 0,
                    ProcessBranch = null,
                    CreationDate = DateTime.UtcNow.Date,
                    Data = null
                };
                auxViewDataModelList.Add(emptyModel);
                return await Task.Run(() => View("GetProcessFieldDataByVersions", auxViewDataModelList));
            }

            return await Task.Run(() => View("GetProcessFieldDataByVersions", modelsToDisplay[pageIndex]));
        }


        [HttpPost("/Data/GetStoredWebForm/")]
        public async Task<ActionResult> GetStoredWebForm(string ObjectId, string ProcessId, string ProcessVersion, string ProcessBranch)
        {
            List<WebFormModel> webFormElements = new List<WebFormModel>();

            //Se o modelo de dados for nulo, logo estamos perante um caso de pedido inválido (Bad Request)
            if (string.IsNullOrEmpty(ProcessId))
            {
                return BadRequest();
            }

            _Connection.DatabaseConnection();

            //Chamadas aos serviços - Ligação à base de dados
            _Metadata.SetDatabase(_Connection.GetDatabase());
            _Field.SetDatabase(_Connection.GetDatabase());
            _Properties.SetDatabase(_Connection.GetDatabase());
            _Data.SetDatabase(_Connection.GetDatabase());

            //Obter a lista de camposde um processo;
            List<string> processFields = _Metadata.GetProcessFieldsID(ProcessId);
            DataModel dataModel = _Data.GetDataModel(ObjectId, ProcessId, Convert.ToInt32(ProcessVersion), ProcessBranch);

            //Valores para preenchimento de campos hidden no formulário gerado automaticamente;
            ViewBag.ObjectId = ObjectId;
            ViewBag.ProcessId = ProcessId;
            ViewBag.ProcessVersion = ProcessVersion;
            ViewBag.ProcessBranch = ProcessBranch;

            string ProcessFields = string.Empty;

            for (int j = 0; j < processFields.Count; j++)
            {
                FieldModel fieldModel = _Field.GetField(processFields.ElementAt(j));

                if (j == processFields.Count - 1)
                {
                    ProcessFields += fieldModel.Type;
                }
                else
                {
                    ProcessFields += fieldModel.Type + " ";
                }

                PropertiesModel propertiesModel = _Properties.GetProperties(fieldModel.Properties);

                WebFormModel webFormElement = new WebFormModel()
                {
                    Type = fieldModel.Type,
                    Name = fieldModel.Name,
                    Size = propertiesModel.Size.ToString(),
                    Value = dataModel.Data.ElementAt(j),
                    Maxlength = propertiesModel.Maxlength.ToString(),
                    Required = propertiesModel.Required.ToString(),
                    Readonly = false
                };

                ViewBag.Readonly = "false"; //Vraiavel para controlo da visibilidade do submit button;

                webFormElements.Add(webFormElement);
            }

            //Passar a lista de webform elements a uma classe que vai criar uma array com as linhas a serem renderizadas;
            WebFormTemplate webFormTemplate = new WebFormTemplate(webFormElements);
            List<string> fragments = webFormTemplate.Template();

            string template = string.Empty;
            for (int j = 0; j < fragments.Count; j++)
            {
                if (j == fragments.Count - 1)
                {
                    template += fragments[j];
                }
                else
                {
                    template += (fragments[j] + "|");
                }
            }

            ViewBag.Template = template;

            return await Task.Run(() => View("WebFormGenerator"));
        }


        //Ação para criar um novo webform;
        [HttpPost("/Data/WebFormGenerator")]
        public async Task<ActionResult> WebFormGenerator(ViewMetadataModel model)
        {
            List<WebFormModel> webFormElements = new List<WebFormModel>();

            //Se o modelo de dados for nulo, logo estamos perante um caso de pedido inválido (Bad Request)
            if (model == null)
            {
                return BadRequest();
            }

            if (model.Branch == null)
            {
                return await Task.Run(() => Redirect("/Metadata/SelectBranch?processId="+model.Id+"&processName="+model.Name+"&processVersion="+model.Version+"&processDate="+model.Date+"&processBranches="+model.Branch+"&processState="+model.State+"&isReadonly='true'"));
            }

            //Valores para preenchimento de campos hidden no formulário gerado automaticamente;
            ViewBag.ObjectId = null;
            ViewBag.ProcessId = model.Id;
            ViewBag.ProcessVersion = model.Version;
            ViewBag.ProcessBranch = model.Branch;

            string ProcessFields = string.Empty;

            _Connection.DatabaseConnection();

            //Chamadas aos serviços - Ligação à base de dados
            _Metadata.SetDatabase(_Connection.GetDatabase());
            _Field.SetDatabase(_Connection.GetDatabase());
            _Properties.SetDatabase(_Connection.GetDatabase());
            _Data.SetDatabase(_Connection.GetDatabase());

            List<string> fields = _Metadata.GetProcessFieldsID(model.Id); //Obter os campos existentes no processo seleccionado;

            for (int j = 0; j < fields.Count; j++)
            {
                FieldModel fieldModel = _Field.GetField(fields.ElementAt(j));

                if(j == fields.Count - 1)
                {
                    ProcessFields += fieldModel.Type;
                }
                else
                {
                    ProcessFields += fieldModel.Type + " ";
                }
                 
                PropertiesModel propertiesModel = _Properties.GetProperties(fieldModel.Properties);

                WebFormModel webFormElement = new WebFormModel()
                {
                    Type = fieldModel.Type,
                    Name = fieldModel.Name,
                    Size = propertiesModel.Size.ToString(),
                    Value = string.Empty,
                    Maxlength = propertiesModel.Maxlength.ToString(),
                    Required = propertiesModel.Required.ToString(),
                    Readonly = model.State.Equals("true") ? true : false
                };

                webFormElements.Add(webFormElement);
            }

            ViewBag.Readonly = model.State.Equals("true") ? "true" : "false";

            //Passar a lista de webform elements a uma classe que vai criar uma array com as linhas a serem renderizadas;
            WebFormTemplate webFormTemplate = new WebFormTemplate(webFormElements);
            List<string> fragments = webFormTemplate.Template();

            string template = string.Empty;
            for (int j = 0; j < fragments.Count; j++)
            {
                if (j == fragments.Count - 1)
                {
                    template += fragments[j];
                }
                else
                {
                    template += (fragments[j] + "|");
                }
            }

            ViewBag.Template = template;

            return await Task.Run(() => View("WebFormGenerator"));
        }


        [HttpPost("/Data/SaveWebform")]
        public async Task<ActionResult> SaveWebform(DataModel model)
        {
            if(model == null)
            {
                return BadRequest(); //Pedido Inválido. Motivo: Modelo de dados vazio;
            }

            _Connection.DatabaseConnection(); //Ligação com o servidor de base de dados;
            _Metadata.SetDatabase(_Connection.GetDatabase());
            _Data.SetDatabase(_Connection.GetDatabase()); //Instanciar a ligação entre o serviço e o servidor de base de dados;


            DataModel dataModel = null; //Objeto do tipo dataModel;
            string id = string.Empty; //Armazena o valor correspondente ao ObjectID do modelo de dados;

            /*
             * Verifica o valor do Id do modelo de dados do tipo DataModel, se for null é um novo registo,
             * se já tiver um valor associado é relativo a um registo já existente na base de dados;
             */
            if (string.IsNullOrEmpty(model.Id))
            {
                _KeyGenerates.SetKey(); //Gerar um ObjectId, chave univoca, que identifica o modelo na colecção Data;
                id = _KeyGenerates.GetKey();
            }
            else
            {
                id = model.Id;
            }
            
            /*
             * Criar o objeto do tipo modelo DataModel para combinação ObjectId, ProcessId, ProcessVersion e ProcessBranch.
             */
            dataModel = new DataModel()
            {
                Id = id,
                ProcessId = model.ProcessId,
                ProcessVersion = Convert.ToInt32(model.ProcessVersion),
                ProcessBranch = model.ProcessBranch,
                Data = model.Data,
                Date = DateTime.Now.ToLocalTime()
            };

            /*
             *Processo de criação / atualização do modelo de dados do tipo DataModel; 
             */
            if (string.IsNullOrEmpty(model.Id))
            {
                _Data.CreateDataModel(dataModel); //Registar o novo modelo de dados na colecção Data;
            }
            else
            {
                _Data.UpdateDataModel(dataModel); //Atualizar o modelo de dados na colecção Data;
            }
            
            return await Task.Run(() => Redirect("/Data/GetLastProcessVersions/")); //Redireccionar para a pégina raíz;
        }
    }
}