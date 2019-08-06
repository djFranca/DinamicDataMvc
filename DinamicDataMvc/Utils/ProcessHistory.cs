using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Log;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DinamicDataMvc.Utils
{
    public class ProcessHistory : IProcessHistory
    {
        private IMongoDatabase Database { get; set; }

        public void CreateProcessLog(string key, string id, string name, int version, string operation)
        {
            if(!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(name) && version > 0 && !string.IsNullOrEmpty(operation))
            {
                LogModel log = new LogModel()
                {
                    Id = key,
                    ProcessId = id,
                    ProcessName = name,
                    ProcessVersion = version,
                    Operation = operation,
                    RegisterDateTime = DateTime.Now.ToLocalTime()
                };

                if (Database != null)
                {
                    var collection = Database.GetCollection<LogModel>("History");
                    collection.InsertOneAsync(log);
                }
            }
        }


        public List<LogModel> GetProcessesLogs()
        {
            var collection = Database.GetCollection<LogModel>("History");
            return collection.Find(s => true).ToList();
        }


        public void SetDatabase(IMongoDatabase Database)
        {
            this.Database = Database;
        }
    }
}
