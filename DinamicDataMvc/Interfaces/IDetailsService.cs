using DinamicDataMvc.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IDetailsService
    {
        void SetDatabase(IMongoDatabase Database);

        void ReadFromTable(string name);

        List<MetadataModel> GetModels();
    }
}
