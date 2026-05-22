using Microsoft.Playwright;

namespace PlaywrightMiniProject.Pages;

public class HomePage
{
    private readonly IPage _page;

    // Selectors
    private readonly string _abTestingLink = "text=A/B Testing";
    private readonly string _addRemoveLink = "text=Add/Remove Elements";
    private readonly string _checkboxesLink = "text=Checkboxes";
    private readonly string _dropdownLink = "text=Dropdown";
    private readonly string _dynamicLoadingLink = "text=Dynamic Loading";
    private readonly string _disappearingElementsLink = "text=Disappearing Elements";
    private readonly string _brokenImagesLink = "text=Broken Images";

    public HomePage(IPage page)
    {
        _page = page;
    }

    // Actions
    public async Task GoToAsync()
    {
        await _page.GotoAsync("https://the-internet.herokuapp.com/");
    }

    public async Task ClickABTestingAsync()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "A/B Testing" }).ClickAsync();
    }

    public async Task ClickAddRemoveElementsAsync()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Add/Remove Elements" }).ClickAsync();
    }

    public async Task ClickCheckboxesAsync()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Checkboxes" }).ClickAsync();
    }

    public async Task ClickDropdownAsync()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Dropdown" }).ClickAsync();
    }

    public async Task ClickDynamicLoadingAsync()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Dynamic Loading" }).ClickAsync();
    }

    public async Task ClickDisappearingElementsAsync()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Disappearing Elements" }).ClickAsync();
    }

    public async Task ClickBrokenImagesAsync()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Broken Images" }).ClickAsync();
    }
}