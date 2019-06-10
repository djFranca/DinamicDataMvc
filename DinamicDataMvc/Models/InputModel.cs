using System;

namespace DinamicDataMvc.Models
{
    public class InputModel
    {
        public string Field { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public bool Required { get; set; }

        public int MaxLength { get; set; }

        public int Size { get; set; }

        public InputModel()
        {
            Field = "Input";
            Type = String.Empty;
            Name = String.Empty;
            Required = false;
            MaxLength = 6;
            Size = 20;
        }
    }
}
