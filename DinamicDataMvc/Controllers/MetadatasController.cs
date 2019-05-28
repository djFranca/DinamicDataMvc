using System.Collections.Generic;
using System.Diagnostics;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DinamicDataMvc.Controllers
{
    public class MetadatasController : Controller
    {
        private readonly IMetadata _tempData;

        public MetadatasController(IMetadata tempData)
        {
            _tempData = tempData;
            _tempData.InitializeConnection();
        }

        /*
         * Permite obter lista de processos armazenados na base de dados, sendo que a listagem poderá ser condicionada
         * pela aplicação dos filtros de pesquisa rápida;
         */
        [HttpGet("metadatas/index")]
        public IActionResult Index()
        {
            string name = Request.Query["Metadatas[0].Name"];
            string version = Request.Query["Metadatas[0].Version"];
            string branch = Request.Query["Branches"];

            List<SelectListItem> BranchList = _tempData.GetAllBranches();
            List<Metadata> MetadataList = _tempData.GetAllMetadata(name, version, branch);

            IndexViewModel indexViewModel = new IndexViewModel
            {
                Metadatas = MetadataList,
                Branches = BranchList
            };
            return View(indexViewModel);
        }

        /*
         * Permite obter os detalhes de um deteterminado processo
         */
        [HttpGet("metadatas/details/{id}")]
        public IActionResult Details(string Id)
        {
            var model = _tempData.GetMetadataById(Id);
            if(model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        /*
         * Permite editar os detalhes de um deteterminado processo
         */
        [HttpGet("metadatas/edit/{id}")]
        public IActionResult Edit(string Id)
        {
            var model = _tempData.GetMetadataById(Id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        /*
         * Permite atualizar um processo na base de dados
         */
        [HttpPost("metadatas/update/{id}")]
        public IActionResult Update(Metadata metadata)
        {
            Metadata _metadata = metadata;
            _tempData.UpdateMetadataById(_metadata);
            return View();
        }

        /*
         * Permite apagar um processo da base de dados
         */
        [HttpGet("metadatas/delete/{id}")]
        public IActionResult Delete(string queryId)
        {
            if(queryId == null)
            {
                return BadRequest();
            }

            _tempData.DeleteMetadataById(queryId);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return null;
        }
    }
}