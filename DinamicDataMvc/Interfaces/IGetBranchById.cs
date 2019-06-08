using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IGetBranchById
    {
        void SetDatabase(IMongoDatabase database);

        void ReadFromDatabase(List<string> branchIdList);

        string GetBranches();
    }
}
