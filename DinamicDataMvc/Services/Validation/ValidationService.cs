using DinamicDataMvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinamicDataMvc.Services.Validation
{
    public class ValidationService : IValidationService
    {
        public bool IncrementsVersion(string processID)
        {
            try
            {
                if(processID == null)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }
    }
}
