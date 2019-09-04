using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
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
        [Display(Name = "Process Id")]
        public string ProcessId { get; set; }

        [BindProperty]
        [BsonRequired]
        [BsonElement("ProcessVersion")]
        [Display(Name = "Process Version")]
        public int ProcessVersion { get; set; }

        [BindProperty]
        [BsonRequired]
        [BsonElement("ProcessBranch")]
        [Display(Name = "Process Branch")]
        public string ProcessBranch { get; set; }

        [BindProperty]
        [Required]
        [BsonElement("Data")]
        [Display(Name = " Process Data")]
        public List<string> Data { get; set; }

        [BindProperty]
        [BsonElement("Date")]
        [Display(Name = "Creation Date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }
    }
}
