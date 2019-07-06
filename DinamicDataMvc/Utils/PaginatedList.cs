using DinamicDataMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Utils
{
    public class PaginatedList
    {
        public int PageIndex { get; private set; }

        public int TotalPages { get; private set; }

        public int PageSize { get; }

        private List<ViewMetadataModel> Models;
        private List<List<ViewMetadataModel>> GroupModels;

        public PaginatedList(List<ViewMetadataModel> models, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(models.Count() / (double)pageSize);
            Models = new List<ViewMetadataModel>();
            Models = models;
            GroupModels = new List<List<ViewMetadataModel>>();
            SliceIntoList();
        }

        public void SliceIntoList()
        {
            int inc = 1;

            List<ViewMetadataModel> auxList = new List<ViewMetadataModel>();
            List<ViewMetadataModel> cloneList = Models;

            if(Models.Count() <= PageSize)
            {
                GroupModels.Add(cloneList);
            }

            else if(Models.Count() > PageSize)
            {
                while (cloneList.Count() > 0)
                {
                    if (inc == PageSize + 1)
                    {
                        GroupModels.Add(auxList);
                        auxList.Clear();
                        inc = 1;
                    }
                    auxList.Add(cloneList.ElementAt(0));
                    cloneList.RemoveAt(0);
                    inc++;
                }
            }
        }

        //Returns the list with the requested processes sliced by index
        public List<ViewMetadataModel> GetModelsList(int pageIndex)
        {
            int index = pageIndex - 1;
            return GroupModels.ElementAt(index);
        }
    }
}
