﻿using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Utils;
using MongoDB.Driver;
using System;
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
            Branch = " ";
        }

        public string GetBranches()
        {
            return Branch;
        }

        public void ReadFromDatabase(List<string> idList)
        {
            try
            {
                Branch = " ";

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
                else
                {
                    Console.WriteLine("Error occurred " + ErrorMessages.NullIdentifierException);
                }
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public void SetDatabase(IMongoDatabase database)
        {
            _Database = database;
        }


        /*
         * Metodo que permite obter o identivicador de um branch de um determinado processo, recebendo como argumento de entrada
         * o código correspondente ao branch do qual se pretende obter o moedelo de dados. A lista de códigos é constituida por
         * { Dev : Desenvolvimento, Qa : Qualidade, Prod : Produção }
         */
        public string GetBranchID(string code)
        {
            try
            {
                if(code == null)
                {
                    return string.Empty;
                }
                var collection = _Database.GetCollection<BranchModel>("Branch");
                BranchModel model = collection.Find(s => s.Code == code).Single();
                return model.Id;
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }
    }
}
