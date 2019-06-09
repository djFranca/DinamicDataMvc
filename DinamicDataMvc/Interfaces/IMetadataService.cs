using DinamicDataMvc.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IMetadataService
    {
        void SetDatabase(IMongoDatabase database);

        void SetFilterParameters(string nameFilteringResult, int versionFilteringResult);

        void ReadFromDatababe();

        List<MetadataModel> GetProcessesMetadataList();

        IMongoCollection<MetadataModel> GetMetadata();

        MetadataModel GetModel(string id);

        void DeleteMetadata(string id);
    }
}
