using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Models
{
    public class MetadataService : IMetadata
    {
        private IMongoCollection<Metadata> _collection;

        public List<Metadata> MetadataList { get; set; }

        public List<Metadata> GetAllMetadata(string name, string version, string branch)
        {
            List<Metadata> filtered_list = MetadataList;

            //Filtering Metadata information
            //Filtering by name search value
            if(name != null)
            {
                var filteredMetadataByName = filtered_list.Where(m => m.Name == name).ToList();
                filtered_list.Clear();
                filtered_list = filteredMetadataByName;
            }

            //Filtering by version search value
            if (version != null)
            {
                var filteredMetadataByVersion = filtered_list.Where(m => m.Version == version).ToList();
                filtered_list.Clear();
                filtered_list = filteredMetadataByVersion;
            }

            //Filtering by branch search value
            if (branch != null)
            {
                var filteredMetadataByBranch = filtered_list.Where(m => m.Branches.Contains(branch)).ToList();
                filtered_list.Clear();
                filtered_list = filteredMetadataByBranch;
            }
            //Se o resultado da aplicação dos filtros retornar uma lista sem elementos (vazia).
            if (filtered_list.Count() == 0)
            {
                return MetadataList;
            }
            return filtered_list;
        }

        public List<SelectListItem> GetAllBranches()
        {
            List<SelectListItem> _branches = new List<SelectListItem>();
            SelectListItem item0 = new SelectListItem
            {
                Text = null,
                Value = null
            };
            _branches.Add(item0);

            SelectListItem item1 = new SelectListItem
            {
                Text = "Development",
                Value = "Dev"
            };
            _branches.Add(item1);

            SelectListItem item2 = new SelectListItem
            {
                Text = "Quality",
                Value = "Qa"
            };
            _branches.Add(item2);

            SelectListItem item3 = new SelectListItem
            {
                Text = "Production",
                Value = "Prod"
            };
            _branches.Add(item3);

            return _branches;
        }

        public Metadata GetMetadataById(string Id)
        {
            var metadata = MetadataList.Where(model => model.Id == Id).SingleOrDefault();
            if(metadata == null)
            {
                return null;
            }
            return metadata;
        }

        public void UpdateMetadataById(Metadata metadata)
        {
            _collection.ReplaceOne(a => a.Id == metadata.Id, metadata);
        }


        public void DeleteMetadataById(string Id)
        {
            _collection.DeleteOne(a => a.Id == Id);
        }


        public void InitializeConnection()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("ProcessStoreDb");
            _collection = database.GetCollection<Metadata>("Processes");

            MetadataList = new List<Metadata>();
            MetadataList = _collection.Find(process => true).ToList();
        }
    }
}
