using System.ComponentModel.DataAnnotations;

namespace DinamicDataMvc.Models
{
    public class InputModel
    {
        [Required]
        public string Field { get; set; }

        [Required]
        public string Type { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public bool Required { get; set; }

        public int MaxLength { get; set; }

        public int Size { get; set; }
    }
}
