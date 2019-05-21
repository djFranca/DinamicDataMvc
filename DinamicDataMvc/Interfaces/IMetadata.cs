using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DinamicDataMvc.Models
{
    public interface IMetadata
    {
        List<Metadata> MetadataList { get; set; }

        void InitializeConnection();

        List<Metadata> GetAllMetadata(string name, string version, string branch);

        List<SelectListItem> GetAllBranches();

        Metadata GetMetadataById(string Id);

        void DeleteMetadataById(string Id);

        void UpdateMetadataById(Metadata metadata);
    }
}
