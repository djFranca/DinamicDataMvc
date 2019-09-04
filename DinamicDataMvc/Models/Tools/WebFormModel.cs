using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinamicDataMvc.Models.Tools
{
    public class WebFormModel
    {
        [BindProperty]
        public string Type { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Size { get; set; }

        [BindProperty]
        public string Value { get; set; }

        [BindProperty]
        public string Maxlength { get; set; }

        [BindProperty]
        public string Required { get; set; }

        [BindProperty]
        public bool Readonly { get; set; }
    }
}
