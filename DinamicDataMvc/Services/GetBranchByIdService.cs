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

        private string Branch { get; set; }

        public GetBranchByIdService()
        {
            Branch = String.Empty;
        }

        public string GetBranches()
        {
            return Branch;
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
                        foreach(var item in model)
                        {
                            Branch = item.Description;
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
