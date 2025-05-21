using Blib.UnitTest.Pages;
using Blib.UnitTest.Untils.Configuration;
using Blib.UnitTest.Untils.Configuration.Model;
using OpenQA.Selenium;

namespace Blib.UnitTest.Tests;

public class PrintedDocumentTest : IDisposable
{
    private readonly IWebDriver _webDriver;
    private readonly PrintedDocumentPage _printedDocumentPage;

    public PrintedDocumentTest()
    {
        var environmentConfiguration = ConfigurationManagement.GetInstance();
        _webDriver = environmentConfiguration.GetCurrentWebDriver();
        _printedDocumentPage = new PrintedDocumentPage(
            environmentConfiguration
                .GetAccountModelWithRolePermission(RolePermission.Management),
            environmentConfiguration.GetUrlBuilderInstance(), 
            _webDriver, environmentConfiguration.GetWailTimeOut(_webDriver));
    }

    [Fact]
    public void CreateIndividualRegistrationForDigitalPrintedDocument_ThenChangeStatusIsNotReady()
    {
        _printedDocumentPage.CreateIndividualRegistrationForDigitalPrintedDocument(out var firstIndividualRegistration, out var lastIndividualRegistration);
        Assert.Equal(firstIndividualRegistration+1,lastIndividualRegistration);
    }

    public void Dispose()
    {
        _webDriver.Quit();
    }
}