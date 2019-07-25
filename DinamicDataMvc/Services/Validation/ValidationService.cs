using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinamicDataMvc.Services.Validation
{
    public class ValidationService : IValidationService
    {
        private IMongoDatabase _Database;

        public void SetDatabase(IMongoDatabase Database)
        {
            _Database = Database;
        }
    }
}
