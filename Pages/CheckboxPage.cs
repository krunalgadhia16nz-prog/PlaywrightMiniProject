using Microsoft.Playwright;

namespace PlaywrightMiniProject.Pages;

public class CheckboxPage
{
    private readonly IPage _page;

    public CheckboxPage(IPage page)
    {
        _page = page;
    }

    public async Task CheckFirstCheckboxAsync()
    {
        await _page.GetByRole(AriaRole.Checkbox).First.CheckAsync();
    }

    public async Task UncheckSecondCheckboxAsync()
    {
        await _page.GetByRole(AriaRole.Checkbox).Nth(1).UncheckAsync();
    }

    public ILocator CheckboxArea => _page.GetByText("Checkboxes checkbox 1 checkbox");
}