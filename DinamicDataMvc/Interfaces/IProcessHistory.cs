using DinamicDataMvc.Models.Log;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IProcessHistory
    {
        void SetDatabase(IMongoDatabase Database);

        void CreateProcessLog(string key, string id, string name, int version, string operation);

        List<LogModel> GetProcessesLogs();
    }
}
