using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blib.UnitTest.Untils;

/// <summary>
///  Class make wrapper wait to time out try catch block and return message 
/// </summary>
public static class WaitDriverUntil
{
    public static void UntilWithMessage(this WebDriverWait wait, Func<IWebDriver, bool> condition, string? message =  null)
    {
        try
        {   
            wait.Until(condition);
        }
        catch (WebDriverTimeoutException ex)
        {
            throw new WebDriverTimeoutException(message ?? "Time out", ex);
        }
    }
}