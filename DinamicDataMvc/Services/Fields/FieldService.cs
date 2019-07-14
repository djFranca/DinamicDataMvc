using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Field;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services.Fields
{
    public class FieldService : IFieldService
    {
        private IMongoDatabase Database { get; set; }

        private List<FieldModel> Fields { get; set; }

        //private List<PropertiesModel> Properties { get; set; }

        public void SetDatabase(IMongoDatabase database)
        {
            try
            {
                if(database != null)
                {
                    Database = database;
                }
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        public void ReadFromDatabase()
        {
            var collection = Database.GetCollection<FieldModel>("Field");
            Fields = collection.Find(s => true).ToList();
        }

        public string CreateField(FieldModel model)
        {
            try
            {
                if (model != null)
                {
                    var collection = Database.GetCollection<FieldModel>("Field");
                    collection.InsertOneAsync(model);
                    return ((int)StatusCode.Created).ToString() + " - " + StatusCode.Created.ToString();
                }
                return ((int)StatusCode.BadRequest).ToString() + " - " + StatusCode.BadRequest.ToString();
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        public string CreateProperties(PropertiesModel model)
        {
            try
            {
                if(model != null)
                {
                    var collection = Database.GetCollection<PropertiesModel>("Properties");
                    collection.InsertOneAsync(model);
                    return ((int)StatusCode.Created).ToString() + " - " + StatusCode.Created.ToString();
                }
                return ((int)StatusCode.BadRequest).ToString() + " - " + StatusCode.BadRequest.ToString();
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        public string Delete(string id)
        {
            try
            {
                if (id != null)
                {
                    var collection = Database.GetCollection<FieldModel>("Field");
                    collection.DeleteOneAsync(s => s.Id == id);

                    return ((int)StatusCode.Ok).ToString() + " - " + StatusCode.Ok.ToString();
                }
                return ((int)StatusCode.BadRequest).ToString() + " - " +StatusCode.BadRequest.ToString();
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }


        public List<FieldModel> GetFields()
        {
            return Fields;
        }


        public FieldModel GetField(string id)
        {
            if(id != null)
            {
                var collection = Database.GetCollection<FieldModel>("Field");
                return collection.Find(s => s.Id == id).FirstOrDefault();
            }
            return new FieldModel()
            {
                Id = null,
                Type = null,
                Name = null,
                Properties = null,
                Date = Convert.ToDateTime("")
            };
        }


        public PropertiesModel GetProperties(string id)
        {
            if(id != null)
            {
                var collection = Database.GetCollection<PropertiesModel>("Properties");
                return collection.Find(s => s.ID == id).FirstOrDefault();
            }
            return new PropertiesModel()
            {
                ID = null,
                Size = 0,
                Value = null,
                Maxlength = 0,
                Required = false
            };
        }
    }
}
