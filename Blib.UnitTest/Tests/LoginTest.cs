using Blib.UnitTest.Pages;
using Blib.UnitTest.Untils.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blib.UnitTest.Tests;

public class LoginTest : IDisposable
{
    private readonly LoginPage _loginPage;
    private readonly IWebDriver _webDriver;
    public LoginTest()
    {
        var environmentConfiguration = ConfigurationManagement.GetInstance();
        _webDriver = environmentConfiguration.GetCurrentWebDriver();
        _loginPage = new LoginPage(environmentConfiguration.GetUrlBuilderInstance(),
            environmentConfiguration.GetAccountModel,
            _webDriver, environmentConfiguration.GetWailTimeOut(_webDriver));
    }

    [Fact]
    public void Login_WithCorrectAccount_ThenNavigationToHomePage()
    {
        _loginPage.Login();
        Assert.Contains("Home", _webDriver.Url); 
    }

    public void Dispose()
    {
        _webDriver.Quit();
    }
}