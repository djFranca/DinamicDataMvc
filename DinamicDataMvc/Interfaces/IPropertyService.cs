using DinamicDataMvc.Models.Properties;
using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IPropertyService
    {
        void SetDatabase(IMongoDatabase Database);

        string DeleteProperties(string propertiesID);

        PropertiesModel GetProperties(string id);

        string UpdateProperties(string Id, PropertiesModel model);

        string CreateProperties(PropertiesModel model);

        string GetPropertyValue(string propertyId);

        string UpdatePropertyValue(string propertyId, string newValue);
    }
}
