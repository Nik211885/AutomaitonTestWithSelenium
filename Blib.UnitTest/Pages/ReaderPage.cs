using Blib.UnitTest.Data;
using Blib.UnitTest.Untils;
using Blib.UnitTest.Untils.Configuration;
using Blib.UnitTest.Untils.Configuration.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blib.UnitTest.Pages;

public class ReaderPage(IWebDriver webDriver, AccountModel accountModel, WebDriverWait waitTimeOut, UrlBuilder urlBuilder)
{
    private readonly IWebDriver _webDriver = webDriver;
    private readonly UrlBuilder _urlBuilder = urlBuilder;
    private readonly WebDriverWait _waitTimeOut = waitTimeOut;
    private readonly LoginPage _loginPage = new LoginPage(urlBuilder, accountModel, webDriver, waitTimeOut);
    /// <summary>
    ///     Write url in here
    /// </summary>
    private readonly string _createNewReaderUrl = "tao-moi-ban-doc";
    private readonly By _btnAddReader = By.Id("btn-add-reader");
    /// <summary>
    /// 
    /// </summary>
    
    public void CreateNewReader()
    {
        _loginPage.Login();
        var urlCreateNewReader = _urlBuilder.Navigation(_createNewReaderUrl).Build();
        _webDriver.Navigate().GoToUrl(urlCreateNewReader);
        _webDriver.AddDataListByKeyIdInput(CreateNewReaderDataModel.GetFormCreateNewReaderDataModel());
        _webDriver.FindElement(_btnAddReader).Click();
        _waitTimeOut.WaitToastReceived();
    }
}