using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IConnectionManagement
    {
        void DatabaseConnection();

        IMongoDatabase GetDatabase();
    }
}
