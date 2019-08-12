using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models.Config;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services.Metadata
{
    public class BranchService : IBranchService
    {
        private IMongoDatabase _Database;

        private string Branch { get; set; }

        public BranchService()
        {
            Branch = string.Empty;
        }

        /*
         * Método que retorna uma string composta pela descrição de todos os branches, separados por um espaço em branco, armazenados na base de dados.
         * Esta string destina-se sobretudo à visualização e display dos branches de um processo nas listagens em que é necessário apresentar esta informação.
         */
        public string GetBranches()
        {
            return Branch;
        }


        /*
         * Método que permite criar a string composta pelas descrições dos branches através dos ids existentes na lista recebida
         * como argumento de entrada do método, sendo estas descrições separadas por um espaço em branco;
         */
        public void ReadFromDatabase(List<string> idList)
        {
            Branch = string.Empty;

            if(idList.Count > 0)
            {
                if(_Database != null)
                {
                    var collection = _Database.GetCollection<BranchModel>("Branch");

                    foreach(var id in idList)
                    {
                        var model = collection.Find(s => s.Id == id).ToList();
                        foreach (var item in model)
                        {
                            Branch += item.Description + " ";
                        }
                    }
                }
            }
        }


        /*
         * Cria, no serviço, uma instância da base de dados;
         */
        public void SetDatabase(IMongoDatabase database)
        {
            if(database != null)
            {
                _Database = database;
            }
        }


        /*
         * Metodo que permite obter o identivicador de um branch de um determinado processo, recebendo como argumento de entrada
         * o código correspondente ao branch do qual se pretende obter o moedelo de dados. A lista de códigos é constituida por
         * { Dev : Desenvolvimento, Qa : Qualidade, Prod : Produção }
         */
        public string GetBranchID(string code)
        {
            if(string.IsNullOrEmpty(code))
            {
                return string.Empty;
            }
            var collection = _Database.GetCollection<BranchModel>("Branch");
            BranchModel branch = collection.Find(s => s.Code == code).Single();
            return branch.Id;
        }


        /*
         * Método que permite retornar todos os documentos do tipo BranchModel, armazenados na coleção Branch;
         */
        public List<BranchModel> GetBranchModels()
        {
            var collection = _Database.GetCollection<BranchModel>("Branch");
            return collection.Find(s => true).ToList();
        }


        /*
         * Método que permite inserir na colecção Branch um docuemnto do tipo BranchModel
         */
        public void CreateBranch(List<BranchModel> models)
        {
            if(models.Count > 0)
            {
                var collection = _Database.GetCollection<BranchModel>("Branch");
                collection.InsertManyAsync(models);
            }
        }
    }
}
