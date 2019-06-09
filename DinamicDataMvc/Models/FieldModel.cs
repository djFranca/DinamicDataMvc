using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models
{
    public class FieldModel
    {
        [BsonId]
        [Display(Name = "ID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Element")]
        [Display(Name = "Element")]
        public string Element { get; set; }

        [BsonElement("Type")]
        [Display(Name = "Type")]
        public string Type { get; set; }

        [BsonElement("Field")]
        [Display(Name = "Field")]
        public string Field { get; set; }

        [BsonElement("MaxLength")]
        [Display(Name = "Max Length")]
        public int Maxlength { get; set; }

        [BsonElement("Size")]
        [Display(Name = "Size")]
        public int Size { get; set; }

        [BsonElement("Required")]
        [Display(Name = "Required")]
        public bool Required { get; set; }

        [BsonElement("CreationDate")]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }
    }
}
