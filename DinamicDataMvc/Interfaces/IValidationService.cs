using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinamicDataMvc.Interfaces
{
    public interface IValidationService
    {
        void SetDatabase(IMongoDatabase Database);

        bool ProcessExits(string processName);

        int GetProcessLastVersion(string processName);
    }
}
