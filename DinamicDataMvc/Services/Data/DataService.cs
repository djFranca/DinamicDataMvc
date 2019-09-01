using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Data;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
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

        public bool ExistRecordInData(string processId, string processBranch)
        {
            if (!string.IsNullOrEmpty(processId))
            {
                var collection = _Database.GetCollection<DataModel>("Data");

                //Verifica na colecção Data o número de registos existentes para um processo alocado num determinado branch, 
                //ambos recebidos como argumentos de input do micro serviço;
                int numberOfModels = (collection.Find(s => s.ProcessId == processId && s.ProcessBranch == processBranch).ToList()).Count;

                if (numberOfModels == 0) return false;

                return true;
            }

            return false;
        }

        public DataModel GetDataModel(string processId, string processBranch)
        {
            if(string.IsNullOrEmpty(processId) && string.IsNullOrEmpty(processBranch))
            {
                return null;
            }

            var collection = _Database.GetCollection<DataModel>("Data");
            DataModel model = collection.Find(s => s.ProcessId == processId && s.ProcessBranch == processBranch).First();

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

                if (ExistRecordInData(model.ProcessId, model.ProcessBranch))
                {
                    collection.ReplaceOneAsync(s => s.ProcessId == model.ProcessId, model);
                }
                else
                {
                    collection.InsertOneAsync(model);
                }

                return ((int)StatusCode.Created).ToString();
            }

            return ((int)StatusCode.BadRequest).ToString();
        }

        public string GetObjectId(string processId, string processBranch)
        {
            if(!string.IsNullOrEmpty(processId) && !string.IsNullOrEmpty(processBranch))
            {
                var collection = _Database.GetCollection<DataModel>("Data");
                return collection.Find(s => s.ProcessId == processId && s.ProcessBranch == processBranch).First().Id;
            }
            return null;
        }
    }
}
