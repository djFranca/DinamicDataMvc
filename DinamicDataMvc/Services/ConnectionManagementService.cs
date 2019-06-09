using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using System;

namespace DinamicDataMvc.Services
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
            try
            {
                MongoClient _Client = null;

                //Verifica se existe um valor associado à connection_string
                if (_ConnectionString != null)
                {
                    _Client = new MongoClient(_ConnectionString);

                    try
                    {
                        //Verifica se existe um endereço : porto associado a esta conexão e se o nome da base de dados está especificado;
                        if (_Client != null && !String.IsNullOrEmpty(_DatabaseName))
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
            catch
            {
                throw new ArgumentNullException();
            }
        }

        public IMongoDatabase GetDatabase()
        {
            return _Database;
        }
    }
}
