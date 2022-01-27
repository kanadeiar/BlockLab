namespace BlockLab.Tests.Services;

[TestClass]
public class ResearchInfoServiceTests
{
    private Random _rnd = new Random();
    private BlockLabContext _context;
    [TestInitialize]
    public void Init()
    {
        var contextOptions = new DbContextOptionsBuilder<BlockLabContext>()
            .UseInMemoryDatabase(nameof(ResearchInfoServiceTests) + $"{_rnd.Next(10000)}")
            .Options;
        _context = new BlockLabContext(contextOptions);
        _context.Researches.Add(new Research
        {
            Name = "Test",
            Text = "Test",
            TypeResearch = new TypeResearch { Name = "Тест", },
            ResearchObject = new ResearchObject { Name = "Тест", },
            UserId = "test",
            WorkShift = new WorkShift { Name = "Тест", },
        });
        _context.SaveChanges();
    }

    //[TestMethod]
    //public void GetTop10Researches_Call_ShouldType()
    //{
    //    var service = new ResearchInfoService(_context);

    //    var actual = service.GetTop10Researches().Result;

    //    Assert
    //        .IsInstanceOfType(actual, typeof(IEnumerable<ResearchWebModel>));
    //    Assert
    //        .AreEqual(1, actual.Count());
    //}

    //[TestMethod]
    //public void GetResearch_Call_ShouldType()
    //{
    //    var service = new ResearchInfoService(_context);

    //    var actual = service.GetResearch(1).Result;

    //    Assert
    //        .IsInstanceOfType(actual, typeof(ResearchWebModel));
    //}
}

