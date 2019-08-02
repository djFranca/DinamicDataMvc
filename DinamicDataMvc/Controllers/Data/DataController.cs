using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinamicDataMvc.Interfaces;
using DinamicDataMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace DinamicDataMvc.Controllers.Data
{
    public class DataController : Controller
    {
        private readonly IConnectionManagementService _Connection;
        private readonly IMetadataService _Metadata;
        private readonly IPaginationService _Pagination;

        public DataController(IConnectionManagementService Connection, IMetadataService Metadata, IPaginationService Pagination)
        {
            _Connection = Connection;
            _Metadata = Metadata;
            _Pagination = Pagination;
        }


        public async Task<ActionResult> GetLastProcessVersions()
        {
            List<MetadataModel> metadataList = new List<MetadataModel>();

            _Connection.DatabaseConnection();
            var database = _Connection.GetDatabase();
            _Metadata.SetDatabase(database);

            //------------------------------------------
            //Add - Pagination to Page (Phase 1)
            //------------------------------------------
            string pageNumber = Request.Query["Page"];
            if (string.IsNullOrEmpty(pageNumber))
            {
                pageNumber = 1.ToString();
            }
            int pageIndex = Convert.ToInt32(pageNumber);
            ViewBag.PageNumber = pageNumber; //Passa para a view o número da página;
            //------------------------------------------

            List<string> distinctProcessNames = _Metadata.GetProcessNames();

            foreach (string processName in distinctProcessNames)
            {
                int currentVersion = _Metadata.GetProcessByName(processName).Count(); //Contagem do número de documentos existentes com o nome passado como argumento de input;
                MetadataModel metadataModel = _Metadata.GetProcessByVersion(processName, currentVersion);

                metadataList.Add(metadataModel);
            }

            //------------------------------------------
            //Add - Pagination to Page (Phase 2)
            //------------------------------------------
            Dictionary<int, List<MetadataModel>> metadataToDisplay = _Pagination.SetModelsByPage(metadataList);
            int NumberOfPages = metadataToDisplay.Count();
            ViewBag.NumberOfPages = NumberOfPages;
            //------------------------------------------

            return await Task.Run(() => View("GetLastProcessVersions", metadataToDisplay[pageIndex]));
        }
    }
}