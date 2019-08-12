using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IValidationService
    {
        void SetDatabase(IMongoDatabase Database);

        bool ProcessExits(string processName);

        int GetProcessLastVersion(string processName);
    }
}
