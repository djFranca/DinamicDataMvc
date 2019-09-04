using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Data;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services.Data
{
    public class DataService : IDataService
    {
        private IMongoDatabase _Database;

        public void SetDatabase(IMongoDatabase database)
        {
            if (database != null)
            {
                _Database = database;
            }
        }


        public DataModel GetDataModel(string objectId, string processId, int processVersion, string processBranch)
        {
            if(string.IsNullOrEmpty(processId) && string.IsNullOrEmpty(processBranch))
            {
                return null;
            }

            var collection = _Database.GetCollection<DataModel>("Data");
            DataModel model = collection.Find(s => s.Id == objectId && s.ProcessId == processId && s.ProcessVersion == processVersion && s.ProcessBranch == processBranch).First();

            return model;
        }

        /*
         * Serviço que permite adicionar à colecção Data 
         */
        public string CreateDataModel(DataModel model)
        {
            if(model != null)
            {
                var collection = _Database.GetCollection<DataModel>("Data");
                collection.InsertOneAsync(model);

                return ((int)StatusCode.Created).ToString();
            }

            return ((int)StatusCode.BadRequest).ToString();
        }

        public string GetObjectId(string processId, int processVersion, string processBranch, List<string> Data)
        {
            if(!string.IsNullOrEmpty(processId) && !string.IsNullOrEmpty(processBranch))
            {
                var collection = _Database.GetCollection<DataModel>("Data");
                return collection.Find(s => s.ProcessId == processId && s.ProcessVersion == processVersion && s.ProcessBranch == processBranch && s.Data == Data).First().Id;
            }
            return null;
        }


        public List<DataModel> GetDataModelByProcessId(string processId)
        {
            if(processId != null)
            {
                var collection = _Database.GetCollection<DataModel>("Data");
                return collection.Find(s => s.ProcessId == processId).ToList();
            }
            return null;
        }


        public string UpdateDataModel(DataModel model)
        {
            if(model != null)
            {
                var collection = _Database.GetCollection<DataModel>("Data");
                collection.FindOneAndReplace(s => s.Id == model.Id, model);

                return ((int)StatusCode.NoContent).ToString();
            }

            return ((int)StatusCode.BadRequest).ToString();
        }
    }
}
