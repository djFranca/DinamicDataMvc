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

        public void ReadFromDatababe()
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

        public IMongoCollection<MetadataModel> GetMetadata()
        {
            return _Collection;
        }

        public MetadataModel GetModel(string id)
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
        #endregion
    }
}
