using ACompsTestTask.APIMethods;
using NUnit.Framework;
using UserInterfaceVisual.pageObjects;

namespace UserInterfaceVisual;

[TestFixture]
public class Tests : BaseTest
{
    [Test]
    public void checkTheTestResults()
    {
        var mainPage = new MainPage();
        mainPage.State.WaitForDisplayed();
        mainPage.ClickNewUnitButton();
        mainPage.SetUnitName();
        mainPage.ClickDropdownListWithUnitTypes();
        mainPage.SetParentUnit();
        mainPage.ClickCreateButton();
        mainPage.ReloadMainPage();

        Assert.That(mainPage.GetAcomputersCompany(), Is.True, "Company hasn't been created");

        mainPage.SearchAcomputersCompany();
        Assert.Multiple(() =>
        {
            Assert.That(mainPage.CheckACompanyName(), Is.True, "Can't find needed company");
            Assert.That(mainPage.CheckCompanyType(), Is.True, "Company Is incorrect");
        });
    }

    [Test]
    public static async Task GetAllIUnits()
    {
        var response = await ApiMethods.GetAllUnits();
        Assert.That(response.GetResponseCorrectness, Is.True,
            "Request response is incorrect");

        Assert.Multiple(() =>
        {
            Assert.That(response.GetResponseType(), Is.EqualTo("System.Net.Http.HttpResponseMessage"),
                "Type of response is incorrect");
            Assert.That(response.GetStatusCode(), Is.EqualTo("OK"),
                "Response Code is incorrect");
        });
    }

    [Test]
    public static async Task TestPostUnit()
    {
        var response = await ApiMethods.PostNewUnit();
        
        Assert.That(response.GetResponseCorrectness, Is.True,
            "Request response is incorrect");

        Assert.Multiple(() =>
        {
            Assert.That(response.GetResponseType(), Is.EqualTo("System.Net.Http.HttpResponseMessage"),
                "Type of response is incorrect");
            Assert.That(response.GetStatusCode(), Is.EqualTo("OK"),
                "Response Code is incorrect");
        });
    }
}