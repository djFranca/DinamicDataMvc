using DinamicDataMvc.Models.Field;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IFieldService
    {
        void SetDatabase(IMongoDatabase database);

        string CreateField(FieldModel model);

        string Delete(string id);

        FieldModel GetField(string id);

        PropertiesModel GetProperties(string id);

        string CreateProperties(PropertiesModel model);

        string UpdateField(string Id, FieldModel model);

        string UpdateProperties(string Id, PropertiesModel model);
    }
}
