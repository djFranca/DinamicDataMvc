using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using MongoDB.Driver;
using System;
using System.Linq;

namespace DinamicDataMvc.Services
{
    public class GetDataByIdService : IGetDataById
    {
        private IMongoDatabase Database { get; set; }

        DataProcessModel Data{ get; set; }

        public DataProcessModel GetModel()
        {
            return Data;
        }

        public void ReadFromDatabase(string id)
        {
            try
            {
                if (!String.IsNullOrEmpty(id))
                {
                    var collection = Database.GetCollection<DataProcessModel>("Data");
                    Data = collection.Find(s => s.Id == id).First();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void SetDatabase(IMongoDatabase database)
        {
            Database = database;
        }
    }
}
