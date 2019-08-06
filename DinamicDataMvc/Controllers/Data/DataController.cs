using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Models.Data;
using DinamicDataMvc.Models.Field;
using Microsoft.AspNetCore.Mvc;

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

        public DataController(IConnectionManagementService Connection, IMetadataService Metadata, IPaginationService Pagination, IBranchService Branch, IFieldService Field, IPropertyService Property)
        {
            _Connection = Connection;
            _Metadata = Metadata;
            _Pagination = Pagination;
            _Branch = Branch;
            _Field = Field;
            _Property = Property;
        }

        [HttpGet("/Data/GetLastProcessVersions/")]
        public async Task<ActionResult> GetLastProcessVersions()
        {
            List<MetadataModel> metadataList = new List<MetadataModel>();

            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();
            _Metadata.SetDatabase(database);

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

            List<string> distinctProcessNames = _Metadata.GetProcessNames();

            foreach (string processName in distinctProcessNames)
            {
                int currentVersion = _Metadata.GetProcessByName(processName).Count(); //Contagem do número de documentos existentes com o nome passado como argumento de input;
                MetadataModel metadataModel = _Metadata.GetProcessByVersion(processName, currentVersion);

                metadataList.Add(metadataModel);
            }

            //------------------------------------------
            //Add - Pagination to Page (Phase 2)
            //------------------------------------------
            Dictionary<int, List<MetadataModel>> metadataToDisplay = _Pagination.SetModelsByPage(metadataList);
            int NumberOfPages = metadataToDisplay.Count();
            ViewBag.NumberOfPages = NumberOfPages;
            //------------------------------------------

            return await Task.Run(() => View("GetLastProcessVersions", metadataToDisplay[pageIndex]));
        }


        [HttpGet("/Data/GetProcessFieldDataByVersions/")]
        public async Task<ActionResult> GetProcessFieldDataByVersions(string name, string version, List<string> branch)
        {
            _Connection.DatabaseConnection(); //Estabeleçer a ligação com a base de dados;
            var database = _Connection.GetDatabase(); //Obter a ligação com a base de dados;

            _Branch.SetDatabase(database);
            _Field.SetDatabase(database);
            _Property.SetDatabase(database);

            _Branch.ReadFromDatabase(branch);
            string _branches = _Branch.GetBranches();

            string processDetails = name + "," + version + "," + _branches;
            ViewBag.ProcessDetails = processDetails;

            //TODO: Obter as versões anteriores do processo
            List<MetadataModel> allVersions = _Metadata.GetProcessByName(name);

            List<string> versions = new List<string>();
            Dictionary<string, List<string>> fieldTypesByProcess = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> dataByProcessField = new Dictionary<string, List<string>>();

            foreach (var model in allVersions)
            {
                List<string> fields = new List<string>(); //Por cada modelo de metadados são armazenados os seus campos numa lista do tipo string;
                List<string> propertiesId = new List<string>();
                List<string> data = new List<string>();

                foreach(string fieldId in model.Field)
                {
                    var fieldModel = _Field.GetField(fieldId); //Obter o modelo de campos através do seu identificador;
                    fields.Add(fieldModel.Type); //adicionar o tipo à lista de campos de uma versão do processo;

                    //TODO: Obter o valor associado a uma propriedade de um determinado campo: Implementar esta funcionalidade no serviço Properties;
                    var propertiesModel = _Property.GetProperties(fieldModel.Properties);
                    propertiesId.Add(propertiesModel.ID);
                    data.Add(propertiesModel.Value);
                }

                versions.Add(model.Version.ToString()); //Adiciona à lista de versões a versão do processo,
                
                fieldTypesByProcess.Add(model.Version.ToString(), fields); //Adicionar ao dicionário a lista de campos por versão;

                dataByProcessField.Add(model.Version.ToString(), data);
            }

            ViewDataModel modelToDisplay = new ViewDataModel()
            {
                Versions = versions,
                FieldTypesByVersion = fieldTypesByProcess,
                DataByProcessField = dataByProcessField
            };

            return await Task.Run(() => View("GetProcessFieldDataByVersions", modelToDisplay));
        }


        [HttpGet("/Data/UpdateFieldData/{Name}/{Version}/")]
        public async Task<ActionResult> UpdateFieldData(string Name, string Version)
        {
            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();
            _Metadata.SetDatabase(database);
            _Field.SetDatabase(database);
            _Property.SetDatabase(database);

            MetadataModel metadataModel = _Metadata.GetProcessByVersion(Name, Convert.ToInt32(Version));

            ViewBag.ProcessName = Name;
            ViewBag.ProcessVersion = Version;

            string fieldsType = string.Empty;

            List<PropertiesModel> listPropertiesModel = new List<PropertiesModel>();

            foreach (var fieldId in metadataModel.Field)
            {
                FieldModel field = _Field.GetField(fieldId);

                PropertiesModel model = new PropertiesModel()
                {
                    ID = field.Properties,
                    Maxlength = _Property.GetProperties(field.Properties).Maxlength,
                    Size = _Property.GetProperties(field.Properties).Size,
                    Required = _Property.GetProperties(field.Properties).Required,
                    Value = _Property.GetProperties(field.Properties).Value
                };

                fieldsType += field.Type + " ";
                listPropertiesModel.Add(model);
            }

            ViewBag.Fields = fieldsType;

            return await Task.Run(() => View("UpdateFieldData", listPropertiesModel));
        }


        [HttpPost("/data/ConfirmUpdateData/")]
        public async Task<ActionResult> ConfirmUpdateData(PropertiesModel model, string name, string version)
        {
            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();
            _Property.SetDatabase(database);
            _Property.UpdatePropertyValue(model.ID, model.Value);

            return await Task.Run(() => Redirect("/Data/UpdateFieldData/" + name + "/" + version + "/"));
        }
    }
}