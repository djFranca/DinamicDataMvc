using DinamicDataMvc.Models;
using DinamicDataMvc.Models.Field;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IFieldService
    {
        void SetDatabase(IMongoDatabase database);

        void ReadFromDatabase();

        void CreateInputField();

        List<FieldModel> GetFields();
    }
}
