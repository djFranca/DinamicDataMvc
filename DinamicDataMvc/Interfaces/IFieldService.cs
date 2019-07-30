using DinamicDataMvc.Models.Field;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IFieldService
    {
        void SetDatabase(IMongoDatabase database);

        string CreateField(FieldModel model);

        string DeleteField(string id);

        FieldModel GetField(string id);

        string UpdateField(string Id, FieldModel model);
    }
}
