using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DinamicDataMvc.Models
{
    public class MetadataListModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Version")]
        public string Version { get; set; }

        [DisplayName("Date")]
        public string Date { get; set; }

        [DisplayName("Branch")]
        public List<string> Branch { get; set; }

        [DisplayName("State")]
        public string State { get; set; }
    }
}
