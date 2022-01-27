using Bunit;
using Microsoft.Extensions.DependencyInjection;
using Index = BlockLab.Blazor.Index;

namespace BlockLab.Tests.Blazor;

[TestClass]
public class IndexTest
{
    private Random _rnd = new Random();

    //[TestMethod]
    //public void Index_Init_ShouldCorrect()
    //{
    //    using var context = new Bunit.TestContext();
        
    //    context.Services.AddDbContext<BlockLabContext>(options =>
    //    {
    //        options.UseInMemoryDatabase(nameof(IndexTest) + $"{_rnd.Next(10000)}");
    //    });
    //    var dataContext = context
    //        .Services.CreateScope().ServiceProvider.GetService<BlockLabContext>();
    //    dataContext!.Researches.Add(
    //        new Research
    //        {
    //            Name = "Test",
    //            Text = "Test",
    //            TypeResearch = new TypeResearch { Name = "Тест", },
    //            ResearchObject = new ResearchObject { Name = "Тест", },
    //            UserId = "test",
    //            WorkShift = new WorkShift { Name = "Тест", },
    //        });
    //    dataContext!.SaveChanges();
    //    var component = context.RenderComponent<Index>();
    //    Assert.AreEqual(1, component.RenderCount);

    //    component.Render();
    //    var rs = component.Instance.Researches;

    //    Assert.AreEqual(2, component.RenderCount);
    //    Assert
    //        .IsTrue(component.Markup.Contains("<p>Обзор последних введенных результатов анализов по лаборатории.</p>"));
        
    //}


}

