using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IPropertyService
    {
        void Delete(string propertiesID);

        void SetDatabase(IMongoDatabase Database);
    }
}
