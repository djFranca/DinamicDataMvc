using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Properties;
using DinamicDataMvc.Utils;
using MongoDB.Driver;

namespace DinamicDataMvc.Services.Properties
{
    public class PropertyService : IPropertyService
    {
        private IMongoDatabase _Database;

        public void SetDatabase(IMongoDatabase Database)
        {
            _Database = Database;
        }

        public string DeleteProperties(string propertiesID)
        {
            if(propertiesID != null)
            {
                var collection = _Database.GetCollection<PropertiesModel>("Properties");
                collection.DeleteOne(s => s.ID == propertiesID);
                return ((int)StatusCode.NoContent).ToString();
            }
            return ((int)StatusCode.Unauthorized).ToString();
        }

        public PropertiesModel GetProperties(string id)
        {
            if (id != null)
            {
                var collection = _Database.GetCollection<PropertiesModel>("Properties");
                return collection.Find(s => s.ID == id).FirstOrDefault();
            }

            //É gerado um modelo de dados default;
            KeyGenerates KeyId = (new KeyGenerates(8));
            KeyId.SetKey();

            return new PropertiesModel()
            {
                ID = KeyId.GetKey(),
                Size = 0,
                Value = null,
                Maxlength = 0,
                Required = false
            };
        }

        //TODO: Remover o serviço;
        //public string UpdateProperties(string Id, PropertiesModel model)
        //{
        //    if (Id != null && model != null)
        //    {
        //        var collection = _Database.GetCollection<PropertiesModel>("Properties");
        //        collection.ReplaceOneAsync(s => s.ID == Id, model);
        //        return ((int)StatusCode.NoContent).ToString();
        //    }
        //    return ((int)StatusCode.BadRequest).ToString();
        //}

        public string CreateProperties(PropertiesModel model)
        {
            if (model != null)
            {
                var collection = _Database.GetCollection<PropertiesModel>("Properties");
                collection.InsertOneAsync(model);
                return ((int)StatusCode.Created).ToString();
            }
            return ((int)StatusCode.BadRequest).ToString();
        }

        public string GetPropertyValue(string propertyId)
        {
            if (!string.IsNullOrEmpty(propertyId))
            {
                var collection = _Database.GetCollection<PropertiesModel>("Properties");
                PropertiesModel properties = collection.Find(s => s.ID == propertyId).Single();
                return properties.Value;
            }
            return string.Empty;
        }

        //TODO: Remover o serviço;
        public string UpdatePropertyValue(string propertyId, string newValue)
        {
            if (!string.IsNullOrEmpty(propertyId))
            {
                var collection = _Database.GetCollection<PropertiesModel>("Properties");
                PropertiesModel properties = collection.Find(s => s.ID == propertyId).Single();

                properties.Value = newValue; //Substitui o valor dos dados pelo novo valor definido pelo utilizador;

                collection.FindOneAndReplace(s => s.ID == properties.ID, properties);

                return ((int)StatusCode.NoContent).ToString();
            }

            return ((int)StatusCode.NotFound).ToString();
        }
    }
}
