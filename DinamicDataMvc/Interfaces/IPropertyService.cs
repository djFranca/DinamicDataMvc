using DinamicDataMvc.Models.Field;
using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IPropertyService
    {
        void SetDatabase(IMongoDatabase Database);

        void DeleteProperties(string propertiesID);

        PropertiesModel GetProperties(string id);

        string UpdateProperties(string Id, PropertiesModel model);

        string CreateProperties(PropertiesModel model);

        string GetPropertyValue(string propertyId);

        void UpdatePropertyValue(string propertyId, string newValue);
    }
}
