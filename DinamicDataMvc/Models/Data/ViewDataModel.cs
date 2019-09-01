using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models.Data
{
    public class ViewDataModel
    {
        [Display(Name = "Version")]
        public List<string> Versions { get; set; } //última(s) versão(s) do processo;

        public Dictionary<string, List<List<string>>> FieldTypesByVersion { get; set; } //tipos de elementos html (campos);

        public Dictionary<string, List<List<string>>> DataByProcessField { get; set; }  //Valores associados a Data;
    }
}
