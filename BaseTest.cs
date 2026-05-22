using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;

namespace PlaywrightMiniProject;

public class BaseTest : PageTest
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