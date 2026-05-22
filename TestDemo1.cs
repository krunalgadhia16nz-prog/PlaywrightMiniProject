using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightMiniProject;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [SetUp]
    public async Task SetUp()
    {
        await Context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [Test]
    [Category("Smoke")]
    public async Task MyTest()
    {
        await Page.GotoAsync("https://the-internet.herokuapp.com/");
        await Page.GetByRole(AriaRole.Link, new() { Name = "A/B Testing" }).ClickAsync();
        await Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/abtest");
        await Expect(Page.Locator("#page-footer")).ToContainTextAsync("Powered by Elemental Selenium");
        await Expect(Page.Locator("#page-footer")).ToHaveCountAsync(1);
    }

    [TearDown]
    public async Task TearDown()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status ==
            NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            await Context.Tracing.StopAsync(new()
            {
                Path = $"trace-{TestContext.CurrentContext.Test.Name}.zip"
            });
            await Page.ScreenshotAsync(new()
            {
                Path = $"screenshot-{TestContext.CurrentContext.Test.Name}.png"
            });
        }
        else
        {
            await Context.Tracing.StopAsync(new());
        }
    }
}