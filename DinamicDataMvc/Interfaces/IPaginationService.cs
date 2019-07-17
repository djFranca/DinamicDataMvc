using System.Collections.Generic;

namespace DinamicDataMvc.Interfaces
{
    public interface IPaginationService
    {
        Dictionary<int, List<T>> SetModelsByPage<T>(List<T> models);
    }
}
