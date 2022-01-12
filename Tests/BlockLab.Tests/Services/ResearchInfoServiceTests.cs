using Microsoft.EntityFrameworkCore;

namespace BlockLab.Tests.Services;

[TestClass]
public class ResearchInfoServiceTests
{
    private BlockLabContext _context;

    [TestInitialize]
    public void Init()
    {
        var contextOptions = new DbContextOptionsBuilder<BlockLabContext>()
            .UseInMemoryDatabase(nameof(ResearchInfoServiceTests))
            .Options;
        _context = new BlockLabContext(contextOptions);
    }

    [TestMethod]
    public void GetTop10Researches_Call_ShouldType()
    {
        var service = new ResearchInfoService(_context);

        var actual = service.GetTop10Researches().Result;

        Assert
            .IsInstanceOfType(actual, typeof(IEnumerable<ResearchWebModel>));
    }

}

