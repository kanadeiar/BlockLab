namespace BlockLab.Interfaces.Services
{
    public interface IResearchInfoPagiService
    {
        /// <summary> Получение пагинованных отфильтрованных результатов исследований </summary>
        /// <returns>Результаты</returns>
        Task<IEnumerable<ResearchWebModel>> GetPagiFilterResearches();
    }
}
