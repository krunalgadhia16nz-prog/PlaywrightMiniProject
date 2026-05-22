using Microsoft.Playwright;

namespace PlaywrightMiniProject.Pages;

public class DropdownPage
{
    private readonly IPage _page;

    public DropdownPage(IPage page)
    {
        _page = page;
    }

    public async Task SelectOptionAsync(string value)
    {
        await _page.Locator("#dropdown").SelectOptionAsync(new[] { value });
    }

    public ILocator DropdownHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Dropdown List" });
    public ILocator Dropdown => _page.Locator("#dropdown");
}