using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Field;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using System;
using System.Linq;

namespace DinamicDataMvc.Services.Fields
{
    public class FieldService : IFieldService
    {
        private IMongoDatabase _Database;

        public void SetDatabase(IMongoDatabase Database)
        {
            if(Database != null)
            {
                _Database = Database;
            }
        }

        public string CreateField(FieldModel model)
        {
            if (model != null)
            {
                var collection = _Database.GetCollection<FieldModel>("Field");
                collection.InsertOneAsync(model);
                return ((int)StatusCode.Created).ToString();
            }
            return ((int)StatusCode.BadRequest).ToString();
        }

        public string DeleteField(string id)
        {
            if (id != null)
            {
                var collection = _Database.GetCollection<FieldModel>("Field");
                collection.DeleteOneAsync(s => s.Id == id);

                return ((int)StatusCode.Ok).ToString();
            }
            return ((int)StatusCode.BadRequest).ToString();
        }

        public FieldModel GetField(string id)
        {
            if(id != null)
            {
                var collection = _Database.GetCollection<FieldModel>("Field");
                FieldModel field = collection.Find(s => s.Id == id).Single();

                return field;
            }
            return new FieldModel()
            {
                Id = null,
                Type = null,
                Name = null,
                Properties = null,
                Date = Convert.ToDateTime(string.Empty)
            };
        }
    }
}
