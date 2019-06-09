using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using System.Linq;
using System;

namespace DinamicDataMvc.Services
{
    public class StateService : IStateService
    {
        private IMongoDatabase _Database;
        private string _State;

        public StateService()
        {
            _State = String.Empty;
        }

        public string GetStateDescription()
        {
            return _State;
        }

        public void ReadFromDatabase(string id)
        {
            try
            {
                if(_Database != null)
                {
                    if(id != null)
                    {
                        var collection = _Database.GetCollection<StateModel>("State");
                        var model = collection.Find(s => s.Id == id).ToList();
                        foreach(var item in model)
                        {
                            _State = item.Description.ToString();
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Error ocurred: " + ErrorMessages.NullIdentifierException);
                    }
                }
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public void SetDatabase(IMongoDatabase database)
        {
            _Database = database;
        }
    }
}
