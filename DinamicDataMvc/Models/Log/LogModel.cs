using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models.Log
{
    [BsonIgnoreExtraElements]
    public class LogModel
    {
        [BsonId]
        [BsonRequired]
        [BsonElement("Id")]
        [Display(Name = "Log Id")]
        public string Id { get; set; }

        [BindProperty]
        [BsonRequired]
        [BsonElement("ProcessId")]
        [Display(Name = "Process Id")]
        public string ProcessId { get; set; }

        [BindProperty]
        [BsonRequired]
        [BsonElement("ProcessName")]
        [Display(Name = "Process Name")]
        public string ProcessName { get; set; }

        [BindProperty]
        [BsonRequired]
        [BsonElement("ProcessVersion")]
        [Display(Name = "Process Version")]
        public int ProcessVersion { get; set; }

        [BindProperty]
        [BsonRequired]
        [BsonElement("Operation")]
        [Display(Name = "Operation")]
        public string Operation { get; set; }

        [BindProperty]
        [BsonElement("RegisterDateTiem")]
        [Display(Name = "Register Date")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime RegisterDateTime { get; set; }
    }
}
