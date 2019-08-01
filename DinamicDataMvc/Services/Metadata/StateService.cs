using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using MongoDB.Driver;
using System.Linq;
using System.Collections.Generic;

namespace DinamicDataMvc.Services.Metadata
{
    public class StateService : IStateService
    {
        private IMongoDatabase _Database;
        private string _State;

        public StateService()
        {
            _State = string.Empty;
        }


        public string GetStateDescription()
        {
            return _State;
        }


        public string GetStateID(string description)
        {
            if(string.IsNullOrEmpty(description))
            {
                return null;
            }

            var collection = _Database.GetCollection<StateModel>("State");
            StateModel state = collection.Find(s => s.Description == description).Single();
            return state.Id;
        }


        public void ReadFromDatabase(string id)
        {
            if(_Database != null && !string.IsNullOrEmpty(id))
            {
                var collection = _Database.GetCollection<StateModel>("State");
                var model = collection.Find(s => s.Id == id).ToList();
                foreach(var item in model)
                {
                    _State = item.Description.ToString();
                }   
            }
        }


        public void SetDatabase(IMongoDatabase database)
        {
            _Database = database;
        }


        public List<StateModel> GetStateModels()
        {
            var collection = _Database.GetCollection<StateModel>("State");
            return collection.Find(s => true).ToList();
        }


        public void CreateState(List<StateModel> models)
        {
            if(models.Count > 0)
            {
                var collection = _Database.GetCollection<StateModel>("State");
                collection.InsertManyAsync(models);
            }
        }
    }
}
