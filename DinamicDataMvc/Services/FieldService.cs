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

        ObjectModel Data{ get; set; }

        public void CreateInputField(InputModel inputObject)
        {
            var collection = Database.GetCollection<FieldModel>("Field");

            FieldModel model = new FieldModel()
            {
                Element = inputObject
            };

            collection.InsertOne(model);
        }

        public ObjectModel GetModel()
        {
            return Data;
        }

        public void ReadFromDatabase(string id)
        {
            try
            {
                if (!String.IsNullOrEmpty(id))
                {
                    var collection = Database.GetCollection<ObjectModel>("Data");
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
