using DinamicDataMvc.Models.Field;
using System.Collections.Generic;

namespace DinamicDataMvc.Models.Process
{
    public class ViewProcessModel
    {
        public MetadataModel Metadata { get; set; }

        public List<FieldModel> Fields { get; set; }

        public List<PropertiesModel> Properties { get; set; }
    }
}
