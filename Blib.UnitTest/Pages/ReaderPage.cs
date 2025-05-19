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

    public void CreateNewReader()
    {
        _loginPage.Login();
        var urlCreateNewReader = _urlBuilder.Navigation("tao-moi-ban-doc").Build();
        _webDriver.Navigate().GoToUrl(urlCreateNewReader);
        _webDriver.AddDataListByKeyIdInput(CreateNewReaderDataModel.GetFormCreateNewReaderDataModel());
        _webDriver.FindElement(By.Id("btn-add-reader")).Click();
        _waitTimeOut.WaitToToastSuccess("Thêm mới thành công!");
    }
}