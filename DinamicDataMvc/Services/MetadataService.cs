using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services
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

                else if (_NameFilteringResult != null && _VerionFilteringResult == 0)
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
            _Database = database;
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
                if (id != null)
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

        public void CreateMetadata(MetadataModel model)
        {
            var collection = _Database.GetCollection<MetadataModel>("Metadata");
            collection.InsertOne(model);
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

        #endregion
    }
}
