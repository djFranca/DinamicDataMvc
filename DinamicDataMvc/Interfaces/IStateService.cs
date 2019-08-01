using DinamicDataMvc.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IStateService
    {
        void SetDatabase(IMongoDatabase database);

        void ReadFromDatabase(string id);

        string GetStateDescription();

        string GetStateID(string description);

        List<StateModel> GetStateModels();

        void CreateState(List<StateModel> models);
    }
}
