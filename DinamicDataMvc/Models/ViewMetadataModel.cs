using System.ComponentModel;

namespace DinamicDataMvc.Models
{
    public class ViewMetadataModel
    {
        [DisplayName("Identifier")]
        public string Id { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Version")]
        public string Version { get; set; }

        [DisplayName("Creation Date")]
        public string Date { get; set; }

        [DisplayName("Branch")]
        public string Branch { get; set; }

        [DisplayName("Current State")]
        public string State { get; set; }
    }
}
