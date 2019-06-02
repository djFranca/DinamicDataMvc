using DinamicDataMvc.Models;
using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IGetDataById
    {
        void SetDatabase(IMongoDatabase database);

        void ReadFromDatabase(string id);

        DataProcessModel GetModel();
    }
}
