using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models
{
    public class StateModel
    {
        [BsonRequired]
        [BsonElement("Id")]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [BsonElement("Value")]
        [Display(Name = "Active")]
        public bool Value { get; set; }

        [BsonElement("Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
