using BlockLab.Domain.Models;

namespace BlockLab.Interfaces.Services
{
    public interface IResearchInfoPagiService
    {
        /// <summary> Получение пагинованных отфильтрованных результатов исследований </summary>
        Task<ResearchPagiWebModel> GetPagiFilterSortResearches(ResearchFilter filter);
    }
}
