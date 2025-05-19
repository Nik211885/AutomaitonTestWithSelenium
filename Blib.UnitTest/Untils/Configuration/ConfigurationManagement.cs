using Blib.UnitTest.Untils.Configuration.Model;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Support.UI;

namespace Blib.UnitTest.Untils.Configuration;
/// <summary>
///   Management information configuration and instance for test
/// </summary>
public class ConfigurationManagement
{
    /// <summary>
    ///     Singleton just have one instance for test case
    /// </summary>
    private static ConfigurationManagement? _instance;
    /// <summary>
    ///     Information about account need login and test function
    /// </summary>
    private readonly AccountModel? _account;
    /// <summary>
    ///     Information about driver option need create instance for web drivers
    /// </summary>
    private readonly DriverOptionsModel? _driverOptions;
    /// <summary>
    ///     Instance need create helper create url page
    /// </summary>
    private readonly UrlBuilder? _uriBuilder;
    /// <summary>
    ///     Instance for web driver created in driver options with  factory 
    /// </summary>
    private IWebDriver? _webDriver;

    private readonly int _waitTimeOut;
    private ConfigurationManagement()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("config.json", optional: true, reloadOnChange: true)
            .Build();
        var addressModel = configuration.GetSection("Address")
            .Get<AddressModel>();
        _account = configuration.GetSection("Account")
            .Get<AccountModel>();
        _driverOptions = configuration.GetSection("DriverOptions")
            .Get<DriverOptionsModel>();
        _waitTimeOut = configuration.GetValue<int>("Assert:Timeout");
        _uriBuilder = new UrlBuilder(addressModel);
    }
    /// <summary>
    ///     Get instance for configuration if don't have just created new instance otherwise create new instance for
    ///      configuration management
    /// </summary>
    /// <returns>
    ///     Return instance for configuration management
    /// </returns>

    public static ConfigurationManagement GetInstance()
        => _instance ??= new ConfigurationManagement();
    /// <summary>
    ///     Destructed instance for configuration management because gac
    ///     can't recall web driver 
    /// </summary>
    ~ConfigurationManagement()
    {
        _webDriver?.Quit();
    }
    /// <summary>
    ///     Create new instance for web driver in your  option has configuration
    /// </summary>
    /// <returns>
    ///     Return new instance for web driver in your options
    /// </returns>
    /// <exception cref="Exception">
    ///     Throw exception if you try to create new instance
    ///     for web driver but not configuration web driver with key DriverOptions
    /// </exception>
    public IWebDriver CreateWebDriverInstance()
        => WebDriverFactory.CreateWebDriver(_driverOptions 
        ?? throw new Exception("Driver options is null or cant not set key is [DriverOptions]"));
    /// <summary>
    ///     Close web driver in current
    /// </summary>
    public void CloseCurrentWebDriver()
    {
        _webDriver?.Quit();
        _webDriver = null;
    }
    /// <summary>
    ///     Get instance for web driver in current if don't have just create new instance 
    /// </summary>
    /// <returns>
    ///     Return web sdriver
    /// </returns>
    public IWebDriver GetCurrentWebDriver()
        => _webDriver ??= CreateWebDriverInstance();
    /// <summary>
    ///     Create new web driver if have current web driver just close and create new instance
    /// </summary>
    /// <returns>
    ///    Return web driver
    /// </returns>
    public IWebDriver CreateFreshWebDriver()
    {
        CloseCurrentWebDriver();
        _webDriver = CreateWebDriverInstance();
        return _webDriver;
    }
    /// <summary>
    ///     Get url builder helper if you don't has set uri builder
    ///     don't call method if you call please ensure you has configuration with key Addres
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception">
    ///     Throw exception if you not yet configuration for address
    /// </exception>
    public UrlBuilder GetUrlBuilderInstance()
        => _uriBuilder ?? throw new Exception("You not set address");
    /// <summary>
    ///     Get account model make test
    /// </summary>
    /// <exception cref="Exception"></exception>
    public AccountModel GetAccountModel
        => _account ?? throw new Exception("You not set account");
    /// <summary>
    ///     Get wait time with time out in config
    /// </summary>
    /// <param name="driver"></param>
    /// <returns></returns>
    public WebDriverWait GetWailTimeOut(IWebDriver driver)
        => new WebDriverWait(driver, TimeSpan.FromSeconds(_waitTimeOut));
    /// <summary>
    ///     Get wait time with time out in config if driver can not exit it throw expceiton
    /// </summary>
    /// <returns></returns>
    public WebDriverWait GetWaitTimeOutWithCurrentWebDriver()
        => new WebDriverWait(_webDriver ?? throw new Exception("Web driver current can not be null")
            , TimeSpan.FromSeconds(_waitTimeOut));
}