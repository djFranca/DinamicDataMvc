using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using DinamicDataMvc.Models.Field;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services
{
    public class FieldService : IFieldService
    {
        private IMongoDatabase Database { get; set; }

        private FieldModel Field { get; set; }

        private List<FieldModel> Fields { get; set; }


        public void CreateInputField()
        {
            //var collection = Database.GetCollection<FieldModel>("Field");

            //FieldModel model = new FieldModel()
            //{
            //    Element = inputObject
            //};

            //collection.InsertOne(model);
        }


        public List<FieldModel> GetFields()
        {
            return Fields;
        }

        public void ReadFromDatabase()
        {
            //try
            //{
            //    if (!String.IsNullOrEmpty(id))
            //    {
            //        var collection = Database.GetCollection<FieldModel>("Field");
            //        Field = collection.Find(s => s.Id == id).FirstOrDefault().Element;
            //    }
            //}
            //catch (Exception exception)
            //{
            //    throw exception;
            //}

            try
            {
                var collection = Database.GetCollection<FieldModel>("Field");
                Fields = collection.Find(s => true).ToList();
            }
            catch
            {
                throw new NullReferenceException();
            }
        }

        public void SetDatabase(IMongoDatabase database)
        {
            Database = database;
        }
    }
}
