using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models
{
    public class BranchModel
    {
        [BsonRequired]
        [BsonElement("Id")]
        [Display(Name = "Id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Code")]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [BsonElement("Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
