namespace BlockLab.Controllers;

public class HomeController : Controller
{
    private readonly IResearchesInfoService _researchesInfoService;
    public HomeController(IResearchesInfoService researchesInfoService)
    {
        _researchesInfoService = researchesInfoService;
    }

    public IActionResult Index()
    {
        var models = _researchesInfoService.GetTop10Researches();
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

