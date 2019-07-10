using DinamicDataMvc.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IMetadataService
    {
        void SetDatabase(IMongoDatabase database);

        void SetFilterParameters(string nameFilteringResult, int versionFilteringResult);

        void ReadFromDatabase();

        List<MetadataModel> GetProcessesMetadataList();

        IMongoCollection<MetadataModel> GetMetadataCollection();

        MetadataModel GetMetadata(string id);

        void DeleteMetadata(string id);

        void CreateMetadata(MetadataModel model);

        List<MetadataModel> GetProcessByName(string name);

        MetadataModel GetProcessByVersion(string name, int version);
    }
}
