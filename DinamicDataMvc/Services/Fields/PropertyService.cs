using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Field;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using System;

namespace DinamicDataMvc.Services.Fields
{
    public class PropertyService : IPropertyService
    {
        private IMongoDatabase _Database;

        public void SetDatabase(IMongoDatabase Database)
        {
            _Database = Database;
        }

        public void DeleteProperties(string propertiesID)
        {
            try
            {
                if(propertiesID != null)
                {
                    var collection = _Database.GetCollection<PropertiesModel>("Properties");
                    collection.DeleteOne(s => s.ID == propertiesID);
                }
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }

        public PropertiesModel GetProperties(string id)
        {
            if (id != null)
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

        public string UpdateProperties(string Id, PropertiesModel model)
        {
            try
            {
                if (Id != null && model != null)
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

        public string CreateProperties(PropertiesModel model)
        {
            try
            {
                if (model != null)
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
    }
}
