using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DinamicDataMvc.Models
{
    public class IndexViewModel
    {
        public List<Metadata> Metadatas { get; set; }

        public IEnumerable<SelectListItem> Branches { get; set; }
    }
}
