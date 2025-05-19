using Blib.UnitTest.Untils.Configuration.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace Blib.UnitTest.Untils.Configuration;

public static class WebDriverFactory
{
    /// <summary>
    ///     Create new instance for web driver  with options driver option model
    ///     If you have chrome driver update it in config.json to Driver Path and
    ///     sure version in your local has duplicate with version your browser driver
    ///     If you want to my chrome driver it has version 136.0.7103.114 make sure
    ///     your local machine has correct version with chrome
    /// 
    /// </summary>
    /// <param name="driverOptions">
    ///     Options for driver and just support for three driver includes
    ///     chrome, firefox, and edg
    ///     and options like with driver options like disable interface no sandbox and disable dev shm usage
    ///     Support with driver browser
    ///     Chrome : 136.0.7103.114
    ///     Edg:
    ///     Firefox
    /// </param>
    /// <returns></returns>
    /// <exception cref="Exception">
    ///     Throw exception if you choose different driver don't support
    /// </exception>
    public  static IWebDriver CreateWebDriver(DriverOptionsModel driverOptions)
    {
        // You can use package driver management it makes to find version suite for your browser 
        // but i want to control follow 
        var driverPath = string.IsNullOrWhiteSpace(driverOptions.DriverPath)
            ? "Driver"
            : driverOptions.DriverPath;
        switch (driverOptions.DriverType)
        {
            case DriverType.Chrome:
                var chromeOptions = new ChromeOptions();
                if (driverOptions.DisableInterface)
                {
                    chromeOptions.AddArgument("--headless");
                }

                if (!driverOptions.SandBox)
                {
                    chromeOptions.AddArgument("--no-sandbox");
                }

                if (driverOptions.DisableDevShmUsage)
                {
                    chromeOptions.AddArgument("--disable-dev-shm-usage");
                }
                return new ChromeDriver(driverPath, chromeOptions);
            case DriverType.Firefox:
                var firefoxOptions = new FirefoxOptions();
                if (driverOptions.DisableInterface)
                {
                    firefoxOptions.AddArgument("--headless");
                }

                if (!driverOptions.SandBox)
                {
                    firefoxOptions.AddArgument("--no-sandbox");
                }

                if (!driverOptions.DisableDevShmUsage)
                {
                    firefoxOptions.AddArgument("--disable-dev-shm-usage");
                }
                return new FirefoxDriver(driverPath, firefoxOptions);
            case DriverType.Edg:
                var edgeOptions = new EdgeOptions();
                if (driverOptions.DisableInterface)
                {
                    edgeOptions.AddArgument("--headless");
                }

                if (!driverOptions.SandBox)
                {
                    edgeOptions.AddArgument("--no-sandbox");
                }
                if (!driverOptions.DisableDevShmUsage)
                {
                    edgeOptions.AddArgument("--disable-dev-shm-usage");
                }
                return new EdgeDriver(driverPath, edgeOptions);
            default:
                throw new Exception($"Don't support {driverOptions.DriverType} this driver type");
        }
    }
}