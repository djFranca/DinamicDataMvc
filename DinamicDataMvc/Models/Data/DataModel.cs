using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models.Data
{
    [BsonIgnoreExtraElements]
    public class DataModel
    {
        [BsonId]
        [BsonRequired]
        [BsonElement("Id")]
        [Display(Name = "ID")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BindProperty]
        [BsonRequired]
        [BsonElement("ProcessId")]
        [Display(Name = "ProcessId")]
        public string ProcessId { get; set; }

        [BindProperty]
        [BsonRequired]
        [BsonElement("ProcessBranch")]
        [Display(Name = "ProcessBranch")]
        public string ProcessBranch { get; set; }

        [BindProperty]
        [Required]
        [BsonElement("Data")]
        [Display(Name = "Data")]
        public List<string> Data { get; set; }
    }
}
