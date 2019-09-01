using DinamicDataMvc.Models.Properties;
using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IPropertyService
    {
        void SetDatabase(IMongoDatabase Database);

        string DeleteProperties(string propertiesID);

        PropertiesModel GetProperties(string id);

        string CreateProperties(PropertiesModel model);
    }
}
