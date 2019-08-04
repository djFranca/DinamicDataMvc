using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models.Data
{
    public class ViewDataModel
    {
        [Display(Name = "Version")]
        public List<string> Versions { get; set; }

        public Dictionary<string, List<string>> FieldTypesByVersion { get; set; }

        public Dictionary<string, List<string>> DataByProcessField { get; set; } //Properties values
    }
}
