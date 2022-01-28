namespace BlockLab.Tests.Blazor;

[TestClass]
public class IndexTest
{
    private Random _rnd = new Random();

    [TestMethod]
    public void Index_Init_ShouldCorrect()
    {
        using var context = new Bunit.TestContext();
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
        context.Services.AddSingleton(userManagerMock.Object);
        context.Services.AddDbContext<BlockLabContext>(options =>
        {
            options.UseInMemoryDatabase(nameof(IndexTest) + $"{_rnd.Next(10000)}");
        });
        var dataContext = context
            .Services.CreateScope().ServiceProvider.GetService<BlockLabContext>();
        dataContext!.Researches.Add(
            new Research
            {
                Name = "Test",
                Text = "Test",
                TypeResearch = new TypeResearch { Name = "Тест", },
                ResearchObject = new ResearchObject { Name = "Тест", },
                UserId = "test0",
                WorkShift = new WorkShift { Name = "Тест", },
            });
        dataContext!.SaveChanges();
        var component = context.RenderComponent<BlockLab.Blazor.Index>();

        Assert
            .AreEqual(1, component.RenderCount);
        Assert
            .IsTrue(component.Markup.Contains("<p>Обзор последних введенных результатов анализов по лаборатории.</p>"));
    }
}

