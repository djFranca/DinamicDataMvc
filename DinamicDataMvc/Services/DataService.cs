using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinamicDataMvc.Models
{
    public class DataService : IData
    {
        private IMongoCollection<DataModel> _collection;

        public void InitializeConnection()
        {

        }
    }
}
