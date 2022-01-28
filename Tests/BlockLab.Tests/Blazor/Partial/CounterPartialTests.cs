namespace BlockLab.Tests.Blazor.Partial;

[TestClass]
public class CounterPartialTests
{
    [TestMethod]
    public void Counter_ClickIncrement_ShouldCorrect()
    {
        using var context = new Bunit.TestContext();
        var component = context.RenderComponent<CounterPartial>();
        var valueEl = component.Find("p");

        component.Find("button").Click();
        var actual = valueEl.TextContent;

        actual.MarkupMatches("Значение счетчика: 1");
    }
}

