using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services.Metadata
{
    public class MetadataService : IMetadataService
    {
        #region Properties

        private string _NameFilteringResult;
        private int _VerionFilteringResult;
        private IMongoDatabase _Database;
        private IMongoCollection<MetadataModel> _Collection;

        private List<MetadataModel> Model { get; set; }

        #endregion

        #region Constructor

        public MetadataService(string nameFilteringResult, int versionFilteringResult)
        {
            _NameFilteringResult = nameFilteringResult;
            _VerionFilteringResult = versionFilteringResult;
            Model = new List<MetadataModel>();
        }

        #endregion

        #region Methods

        public void SetFilterParameters(string nameFilteringResult, int versionFilteringResult)
        {
            if(!String.IsNullOrEmpty(nameFilteringResult) && versionFilteringResult >= 1)
            {
                _NameFilteringResult = nameFilteringResult;
                _VerionFilteringResult = versionFilteringResult;
            }

            else if(!String.IsNullOrEmpty(nameFilteringResult) && versionFilteringResult == 0)
            {
                _NameFilteringResult = nameFilteringResult;
            }

            else if (String.IsNullOrEmpty(nameFilteringResult) && versionFilteringResult >= 1)
            {
                _VerionFilteringResult = versionFilteringResult;
            }

            else
            {
                _NameFilteringResult = null;
                _VerionFilteringResult = 0;
            }
        }

        public List<MetadataModel> GetProcessesMetadataList()
        {
            return Model;
        }

        //TODO:
        public void ReadFromDatabase()
        {
            #region ReadFromDatabase

            if(_Database != null)
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                Model = collection.Find(s => true).ToList();
                _Collection = collection;

                #region Filtering Data
                if (_NameFilteringResult != null && _VerionFilteringResult != 0)
                {
                    var filteredData = collection.Find(s => s.Name == _NameFilteringResult && s.Version == _VerionFilteringResult).ToList();
                    Model = filteredData;
                }

                else if (_NameFilteringResult == null && _VerionFilteringResult != 0)
                {
                    var filteredData = collection.Find(s => s.Version == _VerionFilteringResult).ToList();
                    Model = filteredData;
                }

                else if (_NameFilteringResult != null && _VerionFilteringResult != 0)
                {
                    var filteredData = collection.Find(s => s.Name == _NameFilteringResult).ToList();
                    Model = filteredData;
                }
                #endregion
            }

            #endregion
        }


        public void SetDatabase(IMongoDatabase database)
        {
            if(database != null)
            {
                _Database = database;
            }
        }

        public IMongoCollection<MetadataModel> GetMetadataCollection()
        {
            return _Collection;
        }

        public MetadataModel GetMetadata(string id)
        {
            MetadataModel model = null;
            try
            {
                if(id != null)
                {
                    var collection = _Database.GetCollection<MetadataModel>("Metadata");
                    model = collection.Find(s => s.Id == id).FirstOrDefault();
                }
            }catch
            {
                throw new KeyNotFoundException();
            }
            return model;
        }

        public void DeleteMetadata(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var collection = _Database.GetCollection<MetadataModel>("Metadata");
                    collection.DeleteOne(s => s.Id == id);
                }
            }
            catch
            {
                throw new KeyNotFoundException();
            }
        }

        public string CreateMetadata(MetadataModel model)
        {
            try
            {
                if(model != null)
                {
                    var collection = _Database.GetCollection<MetadataModel>("Metadata");
                    collection.InsertOneAsync(model);
                    return ((int)StatusCode.Created).ToString() + " - " + StatusCode.Created.ToString();
                }
                return ((int)StatusCode.BadRequest).ToString() + " - " + StatusCode.BadRequest.ToString();
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }


        public List<MetadataModel> GetProcessByName(string name)
        {
            try
            {   
                List<MetadataModel> models = new List<MetadataModel>();

                if (name != null)
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
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /*
         * Method that returns a specific model who have the name and version equals input arguments name and version;
         */
        public MetadataModel GetProcessByVersion(string name, int version)
        {
            try
            {
                if (name != null & version > 0)
                {
                    var collection = _Database.GetCollection<MetadataModel>("Metadata");
                    MetadataModel model = collection.Find(s => s.Name == name & s.Version == version).FirstOrDefault();
                    return model;
                }
                return null;
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }


        public string AddFieldToProcess(string processID, string fieldID)
        {
            try
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                MetadataModel model = collection.Find(s => s.Id == processID).Single();

                model.Field.Add(fieldID); //Add field ID to the field array into the process Model

                var result = collection.ReplaceOneAsync(s => s.Id == processID, model);


                return ((int)StatusCode.Created).ToString() + " - " + StatusCode.Created.ToString();
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }


        /*
         * Método que permite receber como argumento de entrada o identificador de um determinado processo,
         * incrementando o número de versão desse mesmo processo e procedendo à sua substituição caso o 
         * número de versão seja igual a zero;
         */
        public void SetProcessVersion(string processID)
        {
            try
            {
                if(processID != null)
                {
                    var collection = _Database.GetCollection<MetadataModel>("Metadata");
                    MetadataModel model = collection.Find(s => s.Id == processID).Single();

                    if(model.Version == 0)
                    {

                        model.Version = 1; //Incrementa o número da versão do processo;

                        model = ActivateState(model);

                        collection.ReplaceOneAsync(s => s.Id == processID, model);
                    }
                }
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }


        /*
         * Método que permite ativar o estado de um processo, pois uma vez criado um processo,
         * ele ficará inativo se não for adicionado qualquer campo (FieldModel)
         */
        private MetadataModel ActivateState(MetadataModel model)
        {
            try
            {
                var collection = _Database.GetCollection<StateModel>("State");
                var stateModel = collection.Find(s => s.Value == true).Single();

                model.State = stateModel.Id;

                return model;
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }


        public List<string> GetProcessFieldsID(string processID)
        {
            try
            {
                List<string> processFields = new List<string>();

                if (processID != null)
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
            catch
            {
                throw new ArgumentNullException();
            }
        }

        public void ReplaceMetadata(string ProcessId, MetadataModel model)
        {
            if(!string.IsNullOrEmpty(ProcessId) && model != null)
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                collection.FindOneAndReplace(s => s.Id == ProcessId, model);
            }
        }

        #endregion
    }
}
