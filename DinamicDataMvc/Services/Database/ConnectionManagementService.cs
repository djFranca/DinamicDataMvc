using DinamicDataMvc.Interfaces;
using MongoDB.Driver;
using System;

namespace DinamicDataMvc.Services.Database
{
    public class ConnectionManagementService : IConnectionManagementService
    {
        private IMongoDatabase _Database;
        private readonly string _ConnectionString;
        private readonly string _DatabaseName;

        public ConnectionManagementService(string ConnectionString, string DatabaseName)
        {
            _ConnectionString = ConnectionString;
            _DatabaseName = DatabaseName;
        }

        public void DatabaseConnection()
        {

            //Verifica se existe um valor associado à connection_string
            if (_ConnectionString != null)
            {
                MongoClient _Client = new MongoClient(_ConnectionString);

                try
                {
                    //Verifica se existe um endereço : porto associado a esta conexão e se o nome da base de dados está especificado;
                    if (_Client != null && !string.IsNullOrEmpty(_DatabaseName))
                    {
                        _Database = _Client.GetDatabase(_DatabaseName);
                    }
                }
                catch(Exception exception)
                {
                    throw new MongoClientException(exception.Message);
                }
            }
        }

        public IMongoDatabase GetDatabase()
        {
            return _Database;
        }

        public string GetConnectionString()
        {
            return _ConnectionString;
        }
    }
}
