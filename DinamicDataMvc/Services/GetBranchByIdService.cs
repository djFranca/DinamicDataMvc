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

        private List<string> BranchList { get; set; }

        public GetBranchByIdService()
        {
            BranchList = new List<string>();
        }

        public List<string> GetBranches()
        {
            return BranchList;
        }

        public void ReadFromDatabase(string id)
        {
            try
            {
                if(id != null)
                {
                    if(_Database != null)
                    {
                        var collection = _Database.GetCollection<BranchModel>("Branch");
                        var model = collection.Find(s => s.Id == id).ToList();
                        foreach (var item in model)
                        {
                            BranchList.Add(item.Description);
                        }
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
