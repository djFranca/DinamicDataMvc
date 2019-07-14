using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models.Field
{
    [BsonIgnoreExtraElements]
    public class PropertiesModel
    {
        [BsonId]
        [BsonRequired]
        [BsonElement("Id")]
        [Display(Name = "ID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonRequired]
        [BsonElement("Size")]
        [Display(Name = "Size")]
        public int Size { get; set; }

        [BsonRequired]
        [BsonElement("Value")]
        [Display(Name = "Value")]
        public string Value { get; set; }

        [BsonRequired]
        [BsonElement("Maxlength")]
        [Display(Name = "Max Length")]
        public int Maxlength { get; set; }

        [BsonRequired]
        [BsonElement("Required")]
        [Display(Name = "Required")]
        public bool Required { get; set; }
    }
}
