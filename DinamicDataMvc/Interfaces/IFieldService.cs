using DinamicDataMvc.Models;
using MongoDB.Driver;
using System;

namespace DinamicDataMvc.Interfaces
{
    public interface IFieldService
    {
        void SetDatabase(IMongoDatabase database);

        void ReadFromDatabase(string id);

        InputModel GetFieldCollection();

        void CreateInputField(InputModel model);
    }
}
