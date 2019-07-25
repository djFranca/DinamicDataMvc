using DinamicDataMvc.Models.Field;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IFieldService
    {
        void SetDatabase(IMongoDatabase database);

        void ReadFromDatabase();

        string CreateField(FieldModel model);

        string Delete(string id);

        List<FieldModel> GetFields();

        FieldModel GetField(string id);

        PropertiesModel GetProperties(string id);

        string CreateProperties(PropertiesModel model);

        string UpdateField(string Id, FieldModel model);

        string UpdateProperties(string Id, PropertiesModel model);

        List<string> GetFieldType();

        //string GetFieldProperties(string fieldId);
    }
}
