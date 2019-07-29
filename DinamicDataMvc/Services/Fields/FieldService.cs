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


        public PropertiesModel GetProperties(string id)
        {
            if(id != null)
            {
                var collection = _Database.GetCollection<PropertiesModel>("Properties");
                return collection.Find(s => s.ID == id).FirstOrDefault();
            }
            //Irá ficar numa classe independente - Utils;
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
