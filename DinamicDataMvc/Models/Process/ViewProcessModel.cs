using DinamicDataMvc.Models.Field;
using DinamicDataMvc.Models.Metadata;
using System.Collections.Generic;

namespace DinamicDataMvc.Models.Process
{
    public class ViewProcessModel
    {
        public MetadataModel Metadata { get; set; }

        public List<FieldModel> Fields { get; set; }
    }
}
