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
    /// </summary>
    /// <param name="driverOptions">
    ///     Options for driver and just support for three driver includes
    ///     chrome, firefox, and edg
    ///     and options like with driver options like disable interface no sandbox and disable dev shm usage
    /// </param>
    /// <returns></returns>
    /// <exception cref="Exception">
    ///     Throw exception if you choose different driver don't support
    /// </exception>
    public  static IWebDriver CreateWebDriver(DriverOptionsModel driverOptions)
    {
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
                return new ChromeDriver(driverOptions.DriverPath, chromeOptions);
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
                return new FirefoxDriver(driverOptions.DriverPath, firefoxOptions);
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
                return new EdgeDriver(driverOptions.DriverPath, edgeOptions);
            default:
                throw new Exception($"Don't support {driverOptions.DriverType} this driver type");
        }
    }
}