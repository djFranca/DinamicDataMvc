using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services
{
    public class GetProcessesMetadataService : IGetProcessesMetadata
    {
        #region Properties

        private string _NameFilteringResult;
        private int _VerionFilteringResult;
        private IMongoDatabase _Database;

        private List<MetadataModel> Model { get; set; }

        #endregion

        #region Constructor

        public GetProcessesMetadataService(string nameFilteringResult, int versionFilteringResult)
        {
            _NameFilteringResult = nameFilteringResult;
            _VerionFilteringResult = versionFilteringResult;
            Model = new List<MetadataModel>();
        }

        #endregion

        #region Methods

        public void SetFilterParameters(string nameFilteringResult, int versionFilteringResult)
        {
            _NameFilteringResult = nameFilteringResult;
            _VerionFilteringResult = versionFilteringResult;
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

        #endregion
    }
}
