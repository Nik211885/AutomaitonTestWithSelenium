using Blib.UnitTest.Pages;
using Blib.UnitTest.Untils.Configuration;
using OpenQA.Selenium;

namespace Blib.UnitTest.Tests;

public class LoginTest
{
    private readonly LoginPage _loginPage;
    private readonly IWebDriver _webDriver;
    public LoginTest()
    {
        var environmentConfiguration = ConfigurationManagement.GetInstance();
        _webDriver = environmentConfiguration.GetCurrentWebDriver();
        _loginPage = new LoginPage(environmentConfiguration.GetUrlBuilderInstance(),
            environmentConfiguration.GetAccountModel,
            _webDriver);
    }

    [Fact]
    public void Login_WithCorrectAccount_ThenNavigationToDashboardPage()
    {
        _loginPage.Login();
        Assert.Contains("Dashboard", _webDriver.Url);
    }
}