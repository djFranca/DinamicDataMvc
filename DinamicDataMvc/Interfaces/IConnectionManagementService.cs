using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IConnectionManagementService
    {
        void DatabaseConnection();

        IMongoDatabase GetDatabase();

        string GetConnectionString();
    }
}
