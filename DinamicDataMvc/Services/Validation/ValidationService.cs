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
            if(string.IsNullOrEmpty(processName))
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


        /*
         * Método qie vermite verificar a última versão do processo armazenada na base de dados.
         */
        public int GetProcessLastVersion(string processName)
        {
            if (string.IsNullOrEmpty(processName))
            {
                return -1;
            }
            var collection = _Database.GetCollection<MetadataModel>("Metadata");

            //Obter todos os processos armazenados cujo nome seja igual ao nome recebido;
            List<MetadataModel> processes = collection.Find(s => s.Name == processName).ToList();

            int version = 0;

            foreach(var process in processes)
            {
                if(process.Version > version)
                {
                    version = process.Version;
                }
            }
            return version;
        }
    }
}
