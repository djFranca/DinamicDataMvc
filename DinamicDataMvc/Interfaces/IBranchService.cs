using DinamicDataMvc.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IBranchService
    {
        void SetDatabase(IMongoDatabase database);

        void ReadFromDatabase(List<string> branchIdList);

        string GetBranches();

        string GetBranchID(string code);

        List<BranchModel> GetBranchModels();

        void CreateBranch(List<BranchModel> models);
    }
}
