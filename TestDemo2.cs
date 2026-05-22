using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightMiniProject.Pages;

namespace PlaywrightMiniProject;

[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests2 : BaseTest  // ✅ inherits SetUp and TearDown
{
    private HomePage _homePage;
    private AddRemovePage _addRemovePage;
    private CheckboxPage _checkboxPage;
    private DropdownPage _dropdownPage;

    [SetUp]

public new async Task SetUp()
{
   // await base.SetUp();  // ✅ calls BaseTest SetUp (tracing)
    
    // initialize page objects
    _homePage = new HomePage(Page);
    _addRemovePage = new AddRemovePage(Page);
    _checkboxPage = new CheckboxPage(Page);
    _dropdownPage = new DropdownPage(Page);
}


    [Test]
    [Category("Smoke")]
    public async Task ABTestingTest()
    {
        await _homePage.GoToAsync();
        await _homePage.ClickABTestingAsync();
        await Expect(Page).ToHaveURLAsync("https://the-internet.herokuapp.com/abtest");
    }

    [Test]
    [Category("Smoke")]
    public async Task AddRemoveElementsTest()
    {
        await _homePage.GoToAsync();
        await _homePage.ClickAddRemoveElementsAsync();
        await _addRemovePage.ClickAddElementAsync();
        await _addRemovePage.ClickAddElementAsync();
        await Expect(_addRemovePage.Footer).ToContainTextAsync("Powered by Elemental Selenium");
        await _addRemovePage.ClickDeleteButtonAsync(1);
        await _addRemovePage.ClickDeleteButtonAsync(0);
        await Expect(_addRemovePage.Footer).ToBeVisibleAsync();
    }

    [Test]
    [Category("Smoke")]
    public async Task CheckboxesTest()
    {
        await _homePage.GoToAsync();
        await _homePage.ClickCheckboxesAsync();
        await _checkboxPage.CheckFirstCheckboxAsync();
        await _checkboxPage.UncheckSecondCheckboxAsync();
        await Expect(_checkboxPage.CheckboxArea).ToBeVisibleAsync();
    }

    [Test]
    [Category("Smoke")]
    public async Task DropdownTest()
    {
        await _homePage.GoToAsync();
        await _homePage.ClickDropdownAsync();
        await Expect(_dropdownPage.DropdownHeading).ToBeVisibleAsync();
        await _dropdownPage.SelectOptionAsync("1");
        await Expect(_dropdownPage.Dropdown).ToContainTextAsync("Option 1");
    }

   
}