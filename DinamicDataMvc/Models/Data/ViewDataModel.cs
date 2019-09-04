using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models.Data
{
    public class ViewDataModel
    {
        [BindProperty]
        [Display(Name = "Process Id")]
        public string ProcessId { get; set; }

        [BindProperty]
        [Display(Name = "Version")]
        public int ProcessVersion { get; set; }

        [BindProperty]
        [Display(Name = "Branch")]
        public string ProcessBranch { get; set; }

        [BindProperty]
        [Display(Name = "Creation Date")]
        public DateTime CreationDate { get; set; }

        [BindProperty]
        [Display(Name = "Data")]
        public List<string> Data { get; set; }
    }
}
