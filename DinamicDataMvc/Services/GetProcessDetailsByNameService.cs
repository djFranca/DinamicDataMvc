using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services
{
    public class GetProcessDetailsByNameService : IGetProcessDetailsByName
    {
        private List<MetadataModel> ModelsList { get; set; }
        private IMongoDatabase _Database;

        public GetProcessDetailsByNameService()
        {
            ModelsList = new List<MetadataModel>();
        }

        public void SetDatabase(IMongoDatabase Database)
        {
            _Database = Database;
        }

        public void ReadFromTable(string name)
        {
            try
            {
                ModelsList.Clear();

                if (name != null)
                {
                    var collection = _Database.GetCollection<MetadataModel>("Metadata");
                    var result = collection.Find(s => s.Name == name).ToList();
                    foreach (var model in result)
                    {
                        ModelsList.Add(model);
                    }
                }
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public List<MetadataModel> GetModels()
        {
            return ModelsList;
        }
    }
}
