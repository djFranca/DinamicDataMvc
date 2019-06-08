using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models
{
    public class ProcessDetailsModel
    {
        [Display(Name = "Version")]
        public string Version { get; set; }

        [Display(Name = "Creation Date")]
        public string CreationDate { get; set; }

        [Display(Name = "Branches")]
        public string Branches { get; set; }
    }
}
