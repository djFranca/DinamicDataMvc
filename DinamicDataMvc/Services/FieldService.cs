using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using MongoDB.Driver;
using System;
using System.Linq;

namespace DinamicDataMvc.Services
{
    public class FieldService : IFieldService
    {
        private IMongoDatabase Database { get; set; }

        FieldModel Data{ get; set; }

        public FieldModel GetModel()
        {
            return Data;
        }

        public void ReadFromDatabase(string id)
        {
            try
            {
                if (!String.IsNullOrEmpty(id))
                {
                    var collection = Database.GetCollection<FieldModel>("Data");
                    Data = collection.Find(s => s.Id == id).First();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void SetDatabase(IMongoDatabase database)
        {
            Database = database;
        }
    }
}
