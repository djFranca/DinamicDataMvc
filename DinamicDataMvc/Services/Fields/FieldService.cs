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
            try
            {
                var collection = Database.GetCollection<FieldModel>("Field");
                Fields = collection.Find(s => true).ToList();
            }
            catch
            {
                throw new MongoClientException("Database Not Found or Not Connected");
            }
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


        public string UpdateField(string Id, FieldModel model)
        {
            try
            {
                if(Id != null && model != null)
                {
                    var collection = Database.GetCollection<FieldModel>("Field");
                    collection.ReplaceOneAsync(s => s.Id == Id, model);
                    return ((int)StatusCode.NoContent).ToString() + " - " + StatusCode.NoContent.ToString();
                }
                return ((int)StatusCode.BadRequest).ToString() + " - " + StatusCode.BadRequest.ToString();
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }


        public string UpdateProperties(string Id, PropertiesModel model)
        {
            try
            {
                if(Id != null && model != null)
                {
                    var collection = Database.GetCollection<PropertiesModel>("Properties");
                    collection.ReplaceOneAsync(s => s.ID == Id, model);
                    return ((int)StatusCode.NoContent).ToString() + " - " + StatusCode.NoContent.ToString();
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
            //TODO: If in case Fields length value is zero, it must necessery treath this kind of exception
            return Fields;
        }


        public FieldModel GetField(string id)
        {
            if(id != null)
            {
                var collection = Database.GetCollection<FieldModel>("Field");
                FieldModel field = collection.Find(s => s.Id == id).Single();

                return field;
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

        /*
         * Method that returns all field types to construct a choice menu for the process creation;
         */
        public List<string> GetFieldType()
        {
            List<string> _types = new List<string>();
            var collection = Database.GetCollection<FieldModel>("Field");
            var _models = collection.Find(s => true).ToList();
            foreach(var _model in _models)
            {
                if (!_types.Contains(_model.Type))
                {
                    _types.Add(_model.Type);
                }
            }
            return _types;
        }
    }
}
