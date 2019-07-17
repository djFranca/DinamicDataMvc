using DinamicDataMvc.Models.Field;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinamicDataMvc.Models.Metadata
{
    public class ViewProcessModel
    {
        public string Name { get; set; }

        public string Version { get; set; }

        public string CreationDate { get; set; }

        public string Branch { get; set; }

        public List<string> Names { get; set; }

        public List<string> Types { get; set; }

        public List<PropertiesModel> Properties { get; set; }
    }
}
