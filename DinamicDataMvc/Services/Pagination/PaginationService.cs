using DinamicDataMvc.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DinamicDataMvc.Services.Pagination
{
    public class PaginationService : IPaginationService
    {
        private int _totalModelsByPage;

        public PaginationService(int totalModelsByPage)
        {
            _totalModelsByPage = totalModelsByPage;
        }

        public void SetNumberOfModelsByPage(int numberOfModels)
        {
            _totalModelsByPage = numberOfModels;
        }

        public Dictionary<int, List<T>> SetModelsByPage<T>(List<T> models)
        {
            try
            {
                Dictionary<int, List<T>> _pageModels = new Dictionary<int, List<T>>();

                if (models != null)
                {
                    int currentKey = 1;

                    for(int i = 0; i <models.Count(); i += _totalModelsByPage)
                    {
                        var listSlice = models.Skip(i).Take(_totalModelsByPage).ToList();
                        _pageModels.Add(currentKey, listSlice);
                        currentKey++;
                    }

                    return _pageModels;
                }

                _pageModels.Add(1, null); //Não existem modelos de dados para efetuar o display;

                return _pageModels;
            }
            catch
            {
                throw new ArgumentNullException();
            }
        }
    }
}
