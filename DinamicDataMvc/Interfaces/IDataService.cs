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

        bool ExistRecordInData(string processId, string processBranch);

        DataModel GetDataModel(string processId, string processBranch);

        string CreateDataModel(DataModel model);

        string GetObjectId(string processId, string processBranch);
    }
}
