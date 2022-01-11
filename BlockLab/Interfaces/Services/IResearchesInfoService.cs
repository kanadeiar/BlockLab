

namespace BlockLab.Services;

public interface IResearchesInfoService
{
    /// <summary> Получение последних 10 исследований </summary>
    /// <returns>Исследования</returns>
    IEnumerable<ResearchWebModel> GetTop10Researches();
}