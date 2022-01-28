namespace BlockLab.Tests.Services;

[TestClass]
public class ResearchInfoPagiServiceTests
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
            UserId = "test0",
            WorkShift = new WorkShift { Name = "Тест", },
        });
        _context.SaveChanges();
    }

    [TestMethod]
    public void GetPagiFilterSortResearches_Call_ShouldType()
    {
        var userStoreStub = Mock.Of<IUserStore<User>>();
        var userManagerMock = new Mock<UserManager<User>>(userStoreStub, null, null, null, null, null, null, null, null);
        var user = new User 
        { 
            Id = "test0", 
            SurName = "Testov",
            FirstName = "Test",
            Patronymic = "Testovich",
            UserName = "Test", 
            Email = "test@example.com" 
        };
        userManagerMock.Setup(_ => _.FindByIdAsync("test0")).Returns(Task.FromResult(user));
        var filter = new ResearchFilter();
        var service = new ResearchInfoPagiService(_context, userManagerMock.Object);

        var actual = service.GetPagiFilterSortResearches(filter).Result;

        Assert
            .IsInstanceOfType(actual, typeof(ResearchPagiWebModel));
        Assert
            .AreEqual(1, actual.Researches.Count());
    }
}

