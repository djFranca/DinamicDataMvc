using DinamicDataMvc.Models;
using MongoDB.Driver;

namespace DinamicDataMvc.Interfaces
{
    public interface IFieldService
    {
        void SetDatabase(IMongoDatabase database);

        void ReadFromDatabase(string id);

        FieldModel GetModel();
    }
}
