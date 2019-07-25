using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Field;
using MongoDB.Driver;
using System;

namespace DinamicDataMvc.Services.Fields
{
    public class PropertyService : IPropertyService
    {
        private IMongoDatabase _Database;

        public void Delete(string propertiesID)
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


        public void SetDatabase(IMongoDatabase Database)
        {
            _Database = Database;
        }
    }
}
