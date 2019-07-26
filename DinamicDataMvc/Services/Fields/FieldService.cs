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
        private IMongoDatabase _Database { get; set; }

        private List<FieldModel> Fields { get; set; }

        public void SetDatabase(IMongoDatabase Database)
        {
            try
            {
                if(Database != null)
                {
                    _Database = Database;
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
                var collection = _Database.GetCollection<FieldModel>("Field");
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
                    var collection = _Database.GetCollection<FieldModel>("Field");
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
                    var collection = _Database.GetCollection<PropertiesModel>("Properties");
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
                    var collection = _Database.GetCollection<FieldModel>("Field");
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
                    var collection = _Database.GetCollection<PropertiesModel>("Properties");
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
                    var collection = _Database.GetCollection<FieldModel>("Field");
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
            //If in case Fields length value is zero, it must necessery pass an empty model to field model list (Fields);
            if(Fields.Count == 0)
            {
                FieldModel emptyModel = new FieldModel()
                {
                    Id = null,
                    Type = null,
                    Name = null,
                    Properties = null,
                    Date = Convert.ToDateTime(string.Empty)
                };
                Fields.Add(emptyModel);
            }
            return Fields;
        }


        public FieldModel GetField(string id)
        {
            if(id != null)
            {
                var collection = _Database.GetCollection<FieldModel>("Field");
                FieldModel field = collection.Find(s => s.Id == id.ToLower()).Single();

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


        public PropertiesModel GetProperties(string id)
        {
            if(id != null)
            {
                var collection = _Database.GetCollection<PropertiesModel>("Properties");
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
            var collection = _Database.GetCollection<FieldModel>("Field");
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

        //public string GetFieldProperties(string fieldId)
        //{
        //    try
        //    {
        //        string property = null;

        //        if(fieldId != null)
        //        {
        //            var collection = _Database.GetCollection<FieldModel>("Field");
        //            FieldModel model = collection.Find(s => s.Id == fieldId.ToLower()).Single();

        //            property = model.Properties;
        //        }

        //        return property;
        //    }
        //    catch
        //    {
        //        throw new ArgumentNullException();
        //    }
        //}
    }
}
