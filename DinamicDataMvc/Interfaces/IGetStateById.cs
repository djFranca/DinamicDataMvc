using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IGetStateById
    {
        void SetDatabase(IMongoDatabase database);

        void ReadFromDatabase(string id);

        string GetStateDescription();
    }
}
