using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models
{
    public class Metadata
    {
        [BsonId]
        [BsonRequired]
        [BsonElement("Id")]
        [Display(Name = "ID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        [BsonElement("Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [BsonRequired]
        [BsonElement("Version")]
        [Display(Name = "Version")]
        public string Version { get; set; }

        [BsonRequired]
        [BsonElement("Date")]
        [Display(Name = "Creation Date")]
        public string Date { get; set; }

        [BsonElement("Environment")]
        [Display(Name = "Branches")]
        public List<string> Branches { get; set; }
    }
}
