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
        private readonly IPropertyService _Property;
        private readonly IStateService _State;
        private readonly IDataService _Data;
        private readonly IKeyGenerates _KeyGenerates;

        public DataController(IConnectionManagementService Connection, IMetadataService Metadata, IPaginationService Pagination, IBranchService Branch, IFieldService Field, IPropertyService Property, IStateService State, IDataService Data, IKeyGenerates KeyGenerates)
        {
            _Connection = Connection;
            _Metadata = Metadata;
            _Pagination = Pagination;
            _Branch = Branch;
            _Field = Field;
            _Property = Property;
            _State = State;
            _Data = Data;
            _KeyGenerates = KeyGenerates;
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
        public async Task<ActionResult> GetProcessFieldDataByVersions(string name, string version, List<string> branch)
        {
            _Connection.DatabaseConnection(); //Estabeleçer a ligação com a base de dados;
            var database = _Connection.GetDatabase(); //Obter a ligação com a base de dados;

            _Branch.SetDatabase(database);
            _Field.SetDatabase(database);
            _Property.SetDatabase(database);
            _Data.SetDatabase(database);
            _Branch.ReadFromDatabase(branch);

            string _branches = _Branch.GetBranches();
            List<string> splitedBranches = new List<string>();

            for(int i = 0; i < _branches.Split(" ").Length - 1; i++)
            {
                splitedBranches.Add(_branches.Split(" ")[i]);
            }

            string processDetails = name + "," + version + "," + _branches;
            ViewBag.ProcessDetails = processDetails;

            MetadataModel processModel = _Metadata.GetProcessByVersion(name, int.Parse(version));

            Dictionary<string, List<List<string>>> fieldTypesByProcess = new Dictionary<string, List<List<string>>>();
            Dictionary<string, List<List<string>>> dataByProcessField = new Dictionary<string, List<List<string>>>();

            List<List<string>> fieldList = new List<List<string>>();
            List<List<string>> dataList = new List<List<string>>();

            foreach (string processBranch in splitedBranches)
            {
                List<string> fields = new List<string>(); //Por cada modelo de metadados são armazenados os seus campos numa lista do tipo string;
                List<string> data = new List<string>(); //Por cada modelo de metadados são armazenados os valores dos seus campos numa lista do tipo string;

                for (int j = 0; j < processModel.Field.Count; j++)
                {
                    var fieldModel = _Field.GetField(processModel.Field[j]); //Obter o modelo de campos através do seu identificador;
                    fields.Add(fieldModel.Type); //adicionar o tipo à lista de campos de uma versão do processo;

                    //Obter o valor associado a uma propriedade de um determinado campo: Implementar esta funcionalidade no serviço Properties;
                    var propertiesModel = _Property.GetProperties(fieldModel.Properties);

                    //Se o processo para o branch corrente tiver registo na colecção Data, obtem-se o valor Data associado ao campo
                    if(_Data.ExistRecordInData(processModel.Id, processBranch))
                    {
                        DataModel dataModel = _Data.GetDataModel(processModel.Id, processBranch);

                        data.Add(dataModel.Data.ElementAt(j));
                    }
                    else
                    {
                        data.Add(propertiesModel.Value); //Default value added;
                    }
                }
                fieldList.Add(fields);
                dataList.Add(data);
            }

            //Adicionar ao dicionário as listas de campos por branch;
            fieldTypesByProcess.Add(processModel.Version.ToString(), fieldList); 
            dataByProcessField.Add(processModel.Version.ToString(), dataList);
           
            ViewDataModel modelToDisplay = new ViewDataModel()
            {
                Versions = new List<string>() { version },
                FieldTypesByVersion = fieldTypesByProcess,
                DataByProcessField = dataByProcessField
            };

            return await Task.Run(() => View("GetProcessFieldDataByVersions", modelToDisplay));
        }


        [HttpGet("/Data/UpdateFieldData/{Name}/{Version}/{Branch}")]
        public async Task<ActionResult> UpdateFieldData(string Name, string Version, string Branch)
        {
            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();
            _Metadata.SetDatabase(database);
            _Field.SetDatabase(database);
            _Property.SetDatabase(database);
            _Data.SetDatabase(database);

            MetadataModel metadataModel = _Metadata.GetProcessByVersion(Name, Convert.ToInt32(Version));

            ViewBag.ProcessId = metadataModel.Id;
            ViewBag.ProcessName = Name;
            ViewBag.ProcessVersion = Version;
            ViewBag.ProcessBranch = Branch;

            string fieldsType = string.Empty;

            DataModel dataModel = null;

            if(_Data.ExistRecordInData(metadataModel.Id, Branch))
            {
                for (int i = 0; i < metadataModel.Field.Count; i++)
                {
                    FieldModel fieldModel = _Field.GetField(metadataModel.Field.ElementAt(i));
                    fieldsType += fieldModel.Type + " ";
                }
                DataModel filteredModel = _Data.GetDataModel(metadataModel.Id, Branch);

                DataModel model = new DataModel()
                {
                    Id = filteredModel.Id,
                    ProcessId = metadataModel.Id,
                    ProcessBranch = Branch,
                    Data = filteredModel.Data
                };
                dataModel = model;
            }
            else
            {
                List<string> DataValue = new List<string>();
                _KeyGenerates.SetKey(); //Gera um ObjectId, ou seja, uma chave para identificar o valor armazenado;

                foreach (var field in metadataModel.Field)
                {
                    FieldModel fieldModel = _Field.GetField(field);
                    fieldsType += fieldModel.Type + " ";
                    DataValue.Add(_Property.GetPropertyValue(fieldModel.Properties));
                }

                DataModel model = new DataModel()
                {
                    Id = _KeyGenerates.GetKey(),
                    ProcessId = metadataModel.Id,
                    ProcessBranch = Branch,
                    Data = DataValue
                };
                dataModel = model;
            }

            ViewBag.Fields = fieldsType;

            return await Task.Run(() => View("UpdateFieldData", dataModel));
        }


        [HttpPost("/data/ConfirmUpdateData/")]
        public async Task<ActionResult> ConfirmUpdateData(DataModel model)
        {
            _Connection.DatabaseConnection();

            _Data.SetDatabase(_Connection.GetDatabase());

            _Data.CreateDataModel(model);

            return await Task.Run(() => Redirect("/Data/GetLastProcessVersions/"));
        }


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
                return await Task.Run(() => Redirect("/Metadata/SelectBranch?processId="+model.Id+ "&&processName="+model.Name+"&&processVersion="+model.Version+"&&processDate="+model.Date+"&&processBranches="+model.Branch+"&&processState="+model.State+"&&isEditable=true"));
            }

            _Connection.DatabaseConnection();

            //Chamadas aos serviços - Ligação à base de dados
            _Metadata.SetDatabase(_Connection.GetDatabase());
            _Field.SetDatabase(_Connection.GetDatabase());
            _Property.SetDatabase(_Connection.GetDatabase());
            _Data.SetDatabase(_Connection.GetDatabase());

            List<string> fields = _Metadata.GetProcessFieldsID(model.Id); //Obter os campos existentes no processo seleccionado;

            //TODO:
            //Validação: Se o processo Id existe na colecção, se existir armazena-se na lista Data os valores correspondentes aos campos do processo;
            if (_Data.ExistRecordInData(model.Id, model.Branch))
            {
                //Chamar o serviço para obter os valores armazenados na colecção Data por branch
                DataModel dataModel = _Data.GetDataModel(model.Id, model.Branch);
                List<string> Data = dataModel.Data;

                for (int j = 0; j < fields.Count; j++)
                {
                    FieldModel fieldModel = _Field.GetField(fields.ElementAt(j));

                    PropertiesModel propertiesModel = _Property.GetProperties(fieldModel.Properties);

                    WebFormModel webFormElement = new WebFormModel()
                    {
                        Type = fieldModel.Type,
                        Name = fieldModel.Name,
                        Size = propertiesModel.Size.ToString(),
                        Value = Data.ElementAt(j),
                        Maxlength = propertiesModel.Maxlength.ToString(),
                        Required = propertiesModel.Required.ToString(),
                        Readonly = model.State
                    };

                    webFormElements.Add(webFormElement);
                }
            }
            else
            {
                //Se não existirem registos na colecção Data para o branch selecionado é apresentado a versão do web form com os valores por default
                foreach (string field in fields)
                {
                    FieldModel fieldModel = _Field.GetField(field);
                    PropertiesModel propertiesModel = _Property.GetProperties(fieldModel.Properties);

                    WebFormModel webFormElement = new WebFormModel()
                    {
                        Type = fieldModel.Type,
                        Name = fieldModel.Name,
                        Size = propertiesModel.Size.ToString(),
                        Value = propertiesModel.Value,
                        Maxlength = propertiesModel.Maxlength.ToString(),
                        Required = propertiesModel.Required.ToString(),
                        Readonly = model.State
                    };

                    webFormElements.Add(webFormElement);
                }
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
    }
}