using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models
{
    [BsonIgnoreExtraElements]
    public class MetadataModel
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
        public int Version { get; set; }
    }
}
