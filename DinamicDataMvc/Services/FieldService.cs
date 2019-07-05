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

        private InputModel Field { get; set; }


        public void CreateInputField(InputModel inputObject)
        {
            var collection = Database.GetCollection<FieldModel>("Field");

            FieldModel model = new FieldModel()
            {
                Element = inputObject
            };

            collection.InsertOne(model);
        }

        public InputModel GetFieldCollection()
        {
            return Field;
        }

        public void ReadFromDatabase(string id)
        {
            try
            {
                if (!String.IsNullOrEmpty(id))
                {
                    var collection = Database.GetCollection<FieldModel>("Field");
                    Field = collection.Find(s => s.Id == id).FirstOrDefault().Element;
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
