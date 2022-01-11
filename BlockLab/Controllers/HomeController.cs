namespace BlockLab.Controllers;

public class HomeController : Controller
{
    private readonly IResearchInfoService _researchInfoService;
    public HomeController(IResearchInfoService researchInfoService)
    {
        _researchInfoService = researchInfoService;
    }

    public async Task<IActionResult> Index()
    {
        var models = await _researchInfoService.GetTop10Researches();
        return View(models);
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Error(string id)
    {
        switch (id)
        {
            default: return Content($"Status --- {id}");
            case "404": return View("Error404");
        }
    }


}

