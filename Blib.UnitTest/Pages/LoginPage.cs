using Blib.UnitTest.Data;
using Blib.UnitTest.Untils;
using Blib.UnitTest.Untils.Configuration;
using Blib.UnitTest.Untils.Configuration.Model;
using OpenQA.Selenium;

namespace Blib.UnitTest.Pages;

public class LoginPage(UrlBuilder urlBuilder, AccountModel accountModel, IWebDriver webDriver)
{
    private readonly AccountModel _accountModel = accountModel;
    private readonly IWebDriver _webDriver = webDriver;
    private readonly UrlBuilder _urlBuilder = urlBuilder;
    
    public void Login()
    {
        _webDriver.Navigate().GoToUrl(_urlBuilder.Navigation("login").Build());
        _webDriver.AddDataByKeyIdInput(AccountDataModel.GetAccountDataModel(_accountModel));
        _webDriver.FindElement(By.Id("login")).Click();
    }
}