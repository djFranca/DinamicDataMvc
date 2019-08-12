using DinamicDataMvc.Models.Metadata;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IMetadataService
    {
        void SetDatabase(IMongoDatabase database);

        void SetFilterParameters(string nameFilteringResult, string versionFilteringResult);

        void ReadFromDatabase();

        List<MetadataModel> GetProcessesMetadataList();

        MetadataModel GetMetadata(string id);

        void DeleteMetadata(string id);

        string CreateMetadata(MetadataModel model);

        List<MetadataModel> GetProcessByName(string name);

        MetadataModel GetProcessByVersion(string name, int version);

        string AddFieldToProcess(string processID, string fieldID);

        void SetProcessVersion(string processID);

        List<string> GetProcessFieldsID(string processID);

        void ReplaceMetadata(string ProcessId, MetadataModel model);

        List<string> GetProcessNames();
    }
}
