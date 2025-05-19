using Blib.UnitTest.Data;
using Blib.UnitTest.Untils;
using Blib.UnitTest.Untils.Configuration;
using Blib.UnitTest.Untils.Configuration.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blib.UnitTest.Pages;

public class LoginPage(UrlBuilder urlBuilder,
    AccountModel accountModel,
    IWebDriver webDriver,
    WebDriverWait waitTimeOut)
{
    private readonly AccountModel _accountModel = accountModel;
    private readonly IWebDriver _webDriver = webDriver;
    private readonly UrlBuilder _urlBuilder = urlBuilder;
    private readonly WebDriverWait _waitTimeOut = waitTimeOut;

    public void Login()
    {
        var urlLogin = _urlBuilder.Build();
        _webDriver.Navigate().GoToUrl(urlLogin);
        _webDriver.AddDataListByKeyIdInput(AccountDataModel.GetAccountDataModel(_accountModel));
        _webDriver.FindElement(By.Id("btn-loggin")).Click();
        _waitTimeOut.Until(driver=> driver.Url != urlLogin);
    }
}