using DinamicDataMvc.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IGetProcessesMetadata
    {
        void SetDatabase(IMongoDatabase database);

        void SetFilterParameters(string nameFilteringResult, int versionFilteringResult);

        void ReadFromDatababe();

        List<MetadataModel> GetProcessesMetadataList();

        IMongoCollection<MetadataModel> GetMetadata();
    }
}
