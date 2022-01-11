namespace BlockLab.Controllers;

public class ResearchController : Controller
{
    private readonly IResearchInfoPagiService _researchInfoPagiService;
    public ResearchController(IResearchInfoPagiService researchInfoPagiService)
    {
        _researchInfoPagiService = researchInfoPagiService;
    }

    public async Task<IActionResult> Index()
    {
        var models = await _researchInfoPagiService.GetPagiFilterResearches();
        return View(models);
    }
}

