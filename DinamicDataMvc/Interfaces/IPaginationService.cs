using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IPaginationService
    {
        void SetNumberOfModelsByPage(int numberOfModels);

        Dictionary<int, List<T>> SetModelsByPage<T>(List<T> models);
    }
}
