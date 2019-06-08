using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DinamicDataMvc.Models
{
    public class ViewMetadataModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Version")]
        public string Version { get; set; }

        [DisplayName("Date")]
        public string Date { get; set; }

        [DisplayName("Branch")]
        public string Branch { get; set; }

        [DisplayName("State")]
        public string State { get; set; }
    }
}
