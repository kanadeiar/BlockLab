namespace BlockLab.Services;

public interface IResearchInfoService
{
    /// <summary> Получение последних 10 исследований </summary>
    /// <returns>Исследования</returns>
    Task<IEnumerable<ResearchWebModel>> GetTop10Researches();
}