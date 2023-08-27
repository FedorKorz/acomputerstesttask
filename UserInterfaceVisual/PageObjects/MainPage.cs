using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using UserInterfaceVisual.Resources;

namespace UserInterfaceVisual.pageObjects;

public class MainPage : Form
{
    private const string CompanyName = "Acomputers Company";
    private readonly string _parentId = ExternalVarsStorage.ParentId;

    public MainPage() : base(By.CssSelector(".app-layout__logo"), "Main Page")
    {
    }

    private IComboBox CreatedAcomputersCompany => ElementFactory.GetComboBox(
        By.XPath("//div[@title='Acomputers Company']"),
        "Acomputers Compamy");

    private IButton CreateNewUnitButton =>
        ElementFactory.GetButton(By.CssSelector(".el-button.el-button--primary.el-button--default"),
            "Create New Unit Button");

    private ITextBox UnitNameFieldName => ElementFactory.GetTextBox(By.XPath("(//input[@class='el-input__inner'])[2]"),
        "Company Name text field");

    private ITextBox DropdownListWithUnitTypes => ElementFactory.GetTextBox(
        By.XPath("(//input[@class='el-input__inner'])[3]"),
        "Dropdown List with unit types");

    private ITextBox ParentUnit => ElementFactory.GetTextBox(By.XPath("(//input[@class='el-input__inner'])[4]"),
        "Parent Unit Input Field");

    private IButton CreateUnitButton => ElementFactory.GetButton(
        By.XPath("//footer[@class='el-dialog__footer']//button[1]"),
        "Create Unit Button");

    private ITextBox SearchTextBox =>
        ElementFactory.GetTextBox(By.XPath("//input[@class='el-input__inner']"),
            "Search Box");

    private ITextBox CompanyType => ElementFactory.GetTextBox(By.XPath("//div[@title='department']"),
        "Copmany Type");

    public void ClickCreateButton()
    {
        CreateUnitButton.State.WaitForClickable();
        CreateUnitButton.Click();
    }

    public void ClickNewUnitButton()
    {
        CreateNewUnitButton.State.WaitForClickable();
        CreateNewUnitButton.Click();
        DropdownListWithUnitTypes.Click();
    }

    public void SetUnitName()
    {
        UnitNameFieldName.State.WaitForClickable();
        UnitNameFieldName.SendKeys(CompanyName);
    }

    public void ClickDropdownListWithUnitTypes()
    {
        DropdownListWithUnitTypes.State.WaitForClickable();
        DropdownListWithUnitTypes.Click();
    }

    public void SetParentUnit()
    {
        ParentUnit.State.WaitForDisplayed();
        ParentUnit.SendKeys(_parentId);
    }

    public bool GetAcomputersCompany()
    {
        return CreatedAcomputersCompany.State.WaitForDisplayed();
    }

    public void SearchAcomputersCompany()
    {
        SearchTextBox.State.WaitForDisplayed();
        SearchTextBox.SendKeys(CompanyName);
    }

    public void ReloadMainPage()
    {
        AqualityServices.Browser.Refresh();
    }

    public bool CheckACompanyName()
    {
        return CreatedAcomputersCompany.GetText() == CompanyName;
    }

    public bool CheckCompanyType()
    {
        return CompanyType.GetText() == "department";
    }
}