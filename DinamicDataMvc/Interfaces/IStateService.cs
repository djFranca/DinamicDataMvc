using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IStateService
    {
        void SetDatabase(IMongoDatabase database);

        void ReadFromDatabase(string id);

        string GetStateDescription();
    }
}
