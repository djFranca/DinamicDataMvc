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
    }
}
