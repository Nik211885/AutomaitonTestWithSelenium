using Blib.UnitTest.Pages;
using Blib.UnitTest.Untils;
using Blib.UnitTest.Untils.Configuration;
using OpenQA.Selenium;

namespace Blib.UnitTest.Tests;

public class ReaderTest
{
    private readonly IWebDriver _webDriver;
    private readonly ReaderPage _readerPage;
    public ReaderTest()
    {
        var environmentConfiguration = ConfigurationManagement.GetInstance();
        _webDriver = environmentConfiguration.GetCurrentWebDriver();
        _readerPage = new ReaderPage(_webDriver, 
            environmentConfiguration.GetAccountModel, 
            environmentConfiguration.GetWailTimeOut(_webDriver), 
            environmentConfiguration.GetUrlBuilderInstance());
    }

    [Fact]
    public void CreateNewReader_WithInformationReader_ThenNotificationSuccessfully()
    {
        _readerPage.CreateNewReader();
        AsserEx.ToastSuccessWithMessage(_webDriver,"Thêm mới thành công!");
    }
}