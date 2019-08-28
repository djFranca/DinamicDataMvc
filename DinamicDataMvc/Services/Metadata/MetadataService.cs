using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Metadata;
using DinamicDataMvc.Models.Config;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services.Metadata
{
    public class MetadataService : IMetadataService
    {
        private string _NameFilteringResult;
        private string _VerionFilteringResult;
        private IMongoDatabase _Database;
        private List<MetadataModel> Model { get; set; }


        public MetadataService(string nameFilteringResult, string versionFilteringResult)
        {
            _NameFilteringResult = nameFilteringResult;
            _VerionFilteringResult = versionFilteringResult;
            Model = new List<MetadataModel>();
        }


        public void SetFilterParameters(string nameFilteringResult, string versionFilteringResult)
        {
            if(!string.IsNullOrEmpty(nameFilteringResult) && !string.IsNullOrEmpty(versionFilteringResult))
            {
                _NameFilteringResult = nameFilteringResult;
                _VerionFilteringResult = versionFilteringResult;
            }

            else if(!string.IsNullOrEmpty(nameFilteringResult) && string.IsNullOrEmpty(versionFilteringResult))
            {
                _NameFilteringResult = nameFilteringResult;
                _VerionFilteringResult = null;
            }

            else if (string.IsNullOrEmpty(nameFilteringResult) && !string.IsNullOrEmpty(versionFilteringResult))
            {
                _NameFilteringResult = null;
                _VerionFilteringResult = versionFilteringResult;
            }

            else
            {
                _NameFilteringResult = null;
                _VerionFilteringResult = null;
            }
        }

        public List<MetadataModel> GetProcessesMetadataList()
        {
            return Model;
        }

        public void ReadFromDatabase()
        {
            if(_Database != null)
            {
                List<MetadataModel> filteredData = new List<MetadataModel>();
                var collection = _Database.GetCollection<MetadataModel>("Metadata");

                if (_NameFilteringResult != null && _VerionFilteringResult != null)
                {
                    filteredData = collection.Find(s => s.Name == _NameFilteringResult && s.Version == Convert.ToInt32(_VerionFilteringResult)).ToList();
                }

                else if (_NameFilteringResult == null && _VerionFilteringResult != null)
                {
                    filteredData = collection.Find(s => s.Version == Convert.ToInt32(_VerionFilteringResult)).ToList();
                }

                else if (_NameFilteringResult != null && _VerionFilteringResult == null)
                {
                    filteredData = collection.Find(s => s.Name == _NameFilteringResult).ToList();
                }
                else
                {
                    var branch = _Database.GetCollection<StateModel>("State").Find(s => s.Description == "Active").Single();
                    filteredData = collection.Find(s => s.Version > 0 && s.State == branch.Id).ToList();
                }


                //------------------------------------------
                //Obter as últimas versões dos processos
                //------------------------------------------
                List<MetadataModel> finalModels = new List<MetadataModel>();
                List<string> distinctProcessNames = GetProcessNames(filteredData); //Ober os nomes dos processos;

                foreach (string processName in distinctProcessNames)
                {
                    int currentVersion = GetProcessByName(processName).Count(); //Obter a última versão para um determinado processo;
                    MetadataModel metadataModel = GetProcessByVersion(processName, currentVersion);

                    finalModels.Add(metadataModel);

                }
                //------------------------------------------

                Model = finalModels;  //Afeta a lista filtrada ao Modelo de retorno;
            }
        }

        public void SetDatabase(IMongoDatabase database)
        {
            if(database != null)
            {
                _Database = database;
            }
        }

        public MetadataModel GetMetadata(string id)
        {
            MetadataModel model = null;

            if(!string.IsNullOrEmpty(id))
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                model = collection.Find(s => s.Id == id).FirstOrDefault();
            }

            return model;
        }

        public string DeleteMetadata(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                collection.DeleteOne(s => s.Id == id);
                return ((int)StatusCode.NoContent).ToString();
            }
            return ((int)StatusCode.BadRequest).ToString();
        }

        public string CreateMetadata(MetadataModel model)
        {
            if(model == null)
            {
                return ((int)StatusCode.BadRequest).ToString();
            }
                
            var collection = _Database.GetCollection<MetadataModel>("Metadata");
            collection.InsertOneAsync(model);
            return ((int)StatusCode.Created).ToString();
        }

        public List<MetadataModel> GetProcessByName(string name)
        {
            List<MetadataModel> models = new List<MetadataModel>();

            if (!string.IsNullOrEmpty(name))
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                var result = collection.Find(s => s.Name == name).ToList();
                foreach (var model in result)
                {
                    models.Add(model);
                }
            }

            return models;
        }

        /*
         * Method that returns a specific model who have the name and version equals input arguments name and version;
         */
        public MetadataModel GetProcessByVersion(string name, int version)
        {
            if (!string.IsNullOrEmpty(name) & version > 0)
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                MetadataModel model = collection.Find(s => s.Name == name & s.Version == version).FirstOrDefault();
                return model;
            }
            return null;
        }

        public string AddFieldToProcess(string processID, string fieldID)
        {
            if(string.IsNullOrEmpty(processID) && string.IsNullOrEmpty(fieldID))
            {
                return ((int)StatusCode.NotFound).ToString();
            }

            var collection = _Database.GetCollection<MetadataModel>("Metadata");
            MetadataModel model = collection.Find(s => s.Id == processID).Single();

            model.Field.Add(fieldID); //Add field ID to the field array into the process Model

            var result = collection.ReplaceOneAsync(s => s.Id == processID, model);

            return ((int)StatusCode.Created).ToString();
        }

        /*
         * Método que permite receber como argumento de entrada o identificador de um determinado processo,
         * incrementando o número de versão desse mesmo processo e procedendo à sua substituição caso o 
         * número de versão seja igual a zero;
         */
        public void SetProcessVersion(string processID)
        {
            if(!string.IsNullOrEmpty(processID))
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                MetadataModel model = collection.Find(s => s.Id == processID).Single();

                if(model.Version == 0)
                {
                    model.Version = 1; //Incrementa o número da versão do processo;
                    model = ActivateState(model); //Ativa o estado do modelo metadados;
                    collection.ReplaceOneAsync(s => s.Id == processID, model); //Substitui na colecção o modelo anterior, cuja versão = 0;
                }
            }
        }

        /*
         * Método que permite ativar o estado de um processo, pois uma vez criado um processo,
         * ele ficará inativo se não for adicionado qualquer campo (FieldModel)
         */
        private MetadataModel ActivateState(MetadataModel model)
        {
            if(model != null)
            {
                var collection = _Database.GetCollection<StateModel>("State");
                StateModel stateModel = collection.Find(s => s.Value == true).Single();
                model.State = stateModel.Id; //Change state to Active;
            }
            return model;
        }

        public List<string> GetProcessFieldsID(string processID)
        {
            List<string> processFields = new List<string>();

            if (!string.IsNullOrEmpty(processID))
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                MetadataModel process = collection.Find(s => s.Id == processID).Single();

                foreach(var field in process.Field)
                {
                    processFields.Add(field);
                }
            }
            return processFields;
        }

        public string ReplaceMetadata(string ProcessId, MetadataModel model)
        {
            if(!string.IsNullOrEmpty(ProcessId) && model != null)
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                collection.FindOneAndReplace(s => s.Id == ProcessId, model);

                return ((int)StatusCode.NoContent).ToString();
            }
            return ((int)StatusCode.NotFound).ToString();
        }

        public List<string> GetProcessNames(List<MetadataModel> metadataModels)
        {
            List<string> processNames = new List<string>();

            var models = metadataModels;

            //Se a lista de modelos recebida não contiver qualquer elemento;
            if(metadataModels.Count == 0)
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                models = collection.Find(s => true).ToList();
            }

            foreach(var model in models)
            {
                if (!processNames.Contains(model.Name))
                {
                    processNames.Add(model.Name);
                }
            }

            return processNames;
        }
    }
}
