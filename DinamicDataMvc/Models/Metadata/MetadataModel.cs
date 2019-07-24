using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
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

        [BindProperty]
        [BsonRequired]
        [BsonElement("Name")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [BindProperty]
        [BsonRequired]
        [BsonElement("Version")]
        [Display(Name = "Version")]
        public int Version { get; set; }

        [BindProperty]
        [BsonElement("Date")]
        [Display(Name = "Date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime Date { get; set; }

        [BindProperty]
        [BsonElement("State")]
        [Display(Name = "State")]
        public string State { get; set; }

        [BindProperty]
        [Required]
        [BsonElement("Field")]
        [Display(Name = "Field")]
        public List<string> Field { get; set; }

        [BindProperty]
        [BsonElement("Branch")]
        [Display(Name = "Branch")]
        public List<string> Branch { get; set; }
    }
}
