using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models.Field
{
    [BsonIgnoreExtraElements]
    public class FieldModel
    {
        [BsonId]
        [BsonRequired]
        [BsonElement("Id")]
        [Display(Name = "ID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        [BsonElement("Type")]
        public string Type { get; set; }

        [BsonRequired]
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonRequired]
        [BsonElement("Properties")]
        public string Properties { get; set; }

        [BsonElement("CreationDate")]
        [Display(Name = "Creation Date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }
    }
}
