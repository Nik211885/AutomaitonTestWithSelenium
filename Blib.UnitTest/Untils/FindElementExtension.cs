using OpenQA.Selenium;

namespace Blib.UnitTest.Untils;

public static class FindElementExtension
{
    public static List<IWebElement> FindElementIn(this IWebDriver driver,List<By> selectors)
        => selectors.Select(driver.FindElement).ToList();
}