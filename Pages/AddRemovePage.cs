using Microsoft.Playwright;

namespace PlaywrightMiniProject.Pages;

public class AddRemovePage
{
    private readonly IPage _page;

    public AddRemovePage(IPage page)
    {
        _page = page;
    }

    public async Task ClickAddElementAsync()
    {
        await _page.GetByRole(AriaRole.Button, new() { Name = "Add Element" }).ClickAsync();
    }

    public async Task ClickDeleteButtonAsync(int index = 0)
    {
        await _page.GetByRole(AriaRole.Button, new() { Name = "Delete" }).Nth(index).ClickAsync();
    }

    public ILocator Footer => _page.Locator("#page-footer");
    public ILocator AddButton => _page.GetByRole(AriaRole.Button, new() { Name = "Add Element" });
}