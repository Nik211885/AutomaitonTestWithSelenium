using Blib.UnitTest.Data;
using Blib.UnitTest.Untils;
using Blib.UnitTest.Untils.Configuration;
using Blib.UnitTest.Untils.Configuration.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blib.UnitTest.Pages;

public class PrintedDocumentPage(AccountModel accountModel,
    UrlBuilder urlBuilder,
    IWebDriver webDriver,
    WebDriverWait waitTimeOut)
{
    private readonly AccountModel _accountModel =  accountModel;
    private readonly UrlBuilder _urlBuilder =  urlBuilder;
    private readonly IWebDriver _webDriver = webDriver;
    private readonly WebDriverWait _waitTimeOut = waitTimeOut;
    private readonly LoginPage _loginPage = new LoginPage(urlBuilder, accountModel, webDriver, waitTimeOut);
    
    /// <summary>
    ///     Url and all by for 
    /// </summary>
    private readonly string _searchAndReportDigitalPrintDocument = "SearchAndReportPDocument";
    /// <summary>
    ///  Selector button click to modal filter search
    /// </summary>
    private readonly By _btnModalSearchAdvance = By.CssSelector("[data-bs-target='#modalSearchAdvance']");
    /// <summary>
    ///    Selector modal filter for data
    /// </summary>
    private readonly By _modalSearchAdvance = By.Id("modalSearchAdvance");
    /// <summary>
    ///     Selector button search in modal filter
    /// </summary>
    private readonly By _btnSearchAdvance = By.Id("btn_seach2");
    /// <summary>
    ///  Selector button close in modal filter
    /// </summary>
    private readonly By _btnCloseModelSearchAdvance = By.ClassName("btn-close");
    /// <summary>
    ///  Selector switch tab individual registration
    /// </summary>
    private readonly By _tabIndividualRegistration = By.CssSelector("a[href='#emp_document']");
    /// <summary>
    ///    Selector click one row data is digital printed document after click search filter
    /// </summary>
    private readonly By _linkDigitalPrintedDocument =
        By.XPath("//table[@id='tbl_p_search']/tbody/tr[1]");
    /// <summary>
    ///     Selector display find max individual registration  
    /// </summary>
    private readonly By _maxByStoreId = By.Id("max_by_storeid");
    /// <summary>
    ///     Selector first data in individual registration
    /// </summary>
    private readonly By _firstIndividualRegistration = 
        By.XPath("//table[@id='tbl_dkcb']/tbody/tr[1]");
    /// <summary>
    ///     Selector button click to make display new max individual registration 
    /// </summary>
    private readonly By _getMaxIndividualRegistration = 
        By.XPath(".//td[2]/div/a");
    /// <summary>
    /// 
    /// </summary>
    
    public void CreateIndividualRegistrationForDigitalPrintedDocument(out int lastIndividualRegistration
        , out int updateIndividualRegistration)
    {
        // Process with login page
        _loginPage.Login();
        //Navigation to page search report digital print document
        _webDriver.Navigate().GoToUrlAsync(_urlBuilder
            .Navigation(_searchAndReportDigitalPrintDocument).Build());
        // wait to find button can turn on search filter advance
        _waitTimeOut.WaitToFindElement(_btnModalSearchAdvance);
        
        _webDriver.FindElement(_btnModalSearchAdvance).Click();
        // wait to modal input data filter has display
        _waitTimeOut.Until(driver => (driver.FindElement(_modalSearchAdvance)
            .GetAttribute("class") ?? string.Empty).Contains("show"));
        // Load static data
        var searchDigitalDocumentModel = SearchDigitalDocument.GetSearchDigitalDocumentModel();
        // add data to form filter
        _webDriver.AddDataListByKeyIdInput(searchDigitalDocumentModel);
        // btn search
        _webDriver.FindElement(_btnSearchAdvance).Click();
        // wait server send back data for font end
        _waitTimeOut.WaiToDisableModalLoader();
        // find element close modal filter and turn off modal filter
        _webDriver.FindElement(_btnCloseModelSearchAdvance).Click();
        // wait has data in table filter
        _waitTimeOut.WaitToFindElement(_linkDigitalPrintedDocument);
        // Click first row data for table
        _webDriver.FindElement(_linkDigitalPrintedDocument).Click();
        // wait to tab individual registration has exits and click
        _waitTimeOut.WaitToFindElement(_tabIndividualRegistration);
        _webDriver.FindElement(_tabIndividualRegistration).Click();
        // wait to data individual registration has exits
        _waitTimeOut.WaitToFindElement(_firstIndividualRegistration);
        // Get old data make compare data after click register when click button search for form data
        _webDriver.FindElement(_firstIndividualRegistration)
            .FindElement(_getMaxIndividualRegistration).Click();
        _waitTimeOut.WaitToFindElementHasNotNullText(_maxByStoreId);
        var lastLabel = _webDriver.FindElement(_maxByStoreId).Text;
        lastIndividualRegistration = GetMaxIndividualRegistration(lastLabel);
        // Find and click register and wait process completed
        _webDriver.FindElement(_firstIndividualRegistration).FindElement(By.XPath(".//td[1]/a")).Click();
        _waitTimeOut.WaiToDisableModalLoader();
        // Find and click update number after update
        _webDriver.FindElement(_firstIndividualRegistration).FindElement(_getMaxIndividualRegistration).Click();
        _waitTimeOut.WaitToElementHasChangeText(lastLabel, _maxByStoreId);
        var updateLabel = _webDriver.FindElement(_maxByStoreId).Text;
        updateIndividualRegistration = GetMaxIndividualRegistration(updateLabel);
    }

    private int GetMaxIndividualRegistration(string label)
    {
        if (!int.TryParse(
                label.Split(":").Last().Split("(").First().Replace("TN", ""),
                out var result
            ))
        {
            throw new Exception($"I cant not find max by store id in {label}");
        }
        return result;
    }
}