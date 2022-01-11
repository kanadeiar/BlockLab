using BlockLab.Domain.Models;

namespace BlockLab.Controllers;

public class ResearchController : Controller
{
    private readonly IResearchInfoPagiService _researchInfoPagiService;
    public ResearchController(IResearchInfoPagiService researchInfoPagiService)
    {
        _researchInfoPagiService = researchInfoPagiService;
    }

    public async Task<IActionResult> Index(string? name, int? typeId, bool? isNormal, int? objId, ResultSortState order = ResultSortState.NameAsc, int page = 1)
    {
        int pageSize = 20;




        var models = await _researchInfoPagiService.GetPagiFilterResearches();
        return View(models);
    }
}

