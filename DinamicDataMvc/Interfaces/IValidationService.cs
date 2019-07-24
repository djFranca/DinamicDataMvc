using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinamicDataMvc.Interfaces
{
    public interface IValidationService
    {
        bool IncrementsVersion(string processID);
    }
}
