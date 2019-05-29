using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services
{
    public class GetBranchByIdService : IGetBranchById
    {

        private IMongoDatabase _Database;

        private List<string> _BranchList { get; set; }

        public GetBranchByIdService()
        {
            _BranchList = new List<string>();
        }

        public List<string> GetBranches()
        {
            return _BranchList;
        }

        public void ReadFromDatabase(string id)
        {
            try
            {
                if(id != null)
                {
                    var collection = _Database.GetCollection<BranchModel>("Branch");
                    var model = collection.Find(s => s.Id == id).ToList();
                    foreach(var item in model)
                    {
                        _BranchList.Add(item.Description);
                    }
                }
                else
                {
                    Console.WriteLine("Error occurred " + ErrorMessages.NullIdentifierException);
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
