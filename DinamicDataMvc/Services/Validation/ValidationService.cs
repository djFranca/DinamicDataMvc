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

        /*
         * Método que permite criar, no serviço, uma instância da base de dados.
         * Para permitir o acesso à mesma.
         */
        public void SetDatabase(IMongoDatabase Database)
        {
            _Database = Database;
        }

        /*
         * Valida a existência de um processo em que o argumento de entrada é o seu nome.
         * Garantindo que o mesmo só é criado se um nome igual não se encontrar na base de dados.
         */
        public bool ProcessExits(string processName)
        {
            //Verifica se o nome do processo não está a null;
            if(processName != null)
            {
                var collection = _Database.GetCollection<MetadataModel>("Metadata");
                List<MetadataModel> processes = collection.Find(s => s.Name == processName).ToList();

                //Se existem processos com o mesmo nome do processo que vai ser criado;
                if(processes.Count() > 0)
                {
                    return true; //Existem processos, armazenados na base de dados, com o mesmo nome.
                }
                return false; //Não Existem processos, armazenados na base de dados, com o mesmo nome.
            }
            return false;
        }
    }
}
