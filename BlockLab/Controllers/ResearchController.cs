namespace BlockLab.Controllers;

public class ResearchController : Controller
{
    private readonly IResearchInfoPagiService _researchInfoPagiService;
    public ResearchController(IResearchInfoPagiService researchInfoPagiService)
    {
        _researchInfoPagiService = researchInfoPagiService;
    }

    public async Task<IActionResult> Index(string? name, int? typeId, bool? isNormal, int? objId, ResearchSortState order = ResearchSortState.DateAsc, int page = 1, int pageSize = 10)
    {
        var filter = new ResearchFilter
        {
            Name = name,
            TypeId = typeId,
            IsNormal = isNormal,
            ObjId = objId,
            Order = order,
            Page = page,
            PageSize = pageSize,
        };
        var (researches, count) = await _researchInfoPagiService.GetPagiFilterSortResearches(filter);
        var model = new ResearchFilterSortPagiWebModel
        {
            Filter = filter,
            Sort = new ResearchSortWebModel(order),
            Pagi = new PagiWebModel(page, count, pageSize),
            Researches = researches,
        };
        return View(model);
    }
}

