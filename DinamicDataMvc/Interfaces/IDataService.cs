using DinamicDataMvc.Models.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinamicDataMvc.Interfaces
{
    public interface IDataService
    {
        void SetDatabase(IMongoDatabase database);

        DataModel GetDataModel(string objectId, string processId, int processVersion, string processBranch);

        string CreateDataModel(DataModel model);

        string GetObjectId(string processId, int processVersion, string processBranch, List<string> Data);

        List<DataModel> GetDataModelByProcessId(string processId);

        string UpdateDataModel(DataModel model);
    }
}
