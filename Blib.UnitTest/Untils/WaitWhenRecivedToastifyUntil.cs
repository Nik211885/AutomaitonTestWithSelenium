using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blib.UnitTest.Untils;

public static class WaitToastReceivedUntil
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="wait"></param>
    public static void WaitToastReceived(this WebDriverWait wait)
    {
        wait.Until(driver =>
        {
            var toastElement = driver.FindElementIn([
                SelectorStatic.ToastSuccess,
                SelectorStatic.ToastDanger,
                SelectorStatic.ToastInfo,
                SelectorStatic.ToastWaring
            ]);
            foreach (var e in toastElement)
            {
                if (!string.IsNullOrWhiteSpace(e.Text))
                {
                    return true;
                }
            }
            return false;
        });
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="wait"></param>
    /// <param name="message"></param>
    public static void WaitToToastSuccess(this WebDriverWait wait, string message)
    {
        wait.Until(driver => driver.FindElement(SelectorStatic.ToastSuccess).Text == (message));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="wait"></param>
    /// <param name="message"></param>
    public static void WaitToToastWaring(this WebDriverWait wait, string message)
    {
        wait.Until(driver => driver.FindElement(SelectorStatic.ToastWaring).Text.Equals(message));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="wait"></param>
    /// <param name="message"></param>
    public static void WaitToToastInfo(this WebDriverWait wait, string message)
    {
        wait.Until(driver => driver.FindElement(SelectorStatic.ToastInfo).Text.Equals(message));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="wait"></param>
    /// <param name="message"></param>
    public static void WaitToToastDanger(this WebDriverWait wait, string message)
    {
        wait.Until(driver => driver.FindElement(SelectorStatic.ToastDanger).Text.Equals(message));
    }
    /// <summary>
    ///     Wait for modal close 
    /// </summary>
    /// <param name="wait"></param>
    public static void WaiToDisableModalLoader(this WebDriverWait wait)
    {
        wait.Until(driver=> 
            (driver.FindElement(SelectorStatic.LoadModal)
                .GetAttribute("style")?? string.Empty).Equals("display: none;"));
    }
    /// <summary>
    ///     Wait to fine element is disabled in dom
    /// </summary>
    /// <param name="wait"></param>
    /// <param name="selector"></param>
    public static void WaitToFindElement(this WebDriverWait wait, By selector)
    {
        wait.Until(driver => driver.FindElements(selector).Count > 0);
    }
    /// <summary>
    ///     Wait to find element and text is not null
    /// </summary>
    /// <param name="wait"></param>
    /// <param name="selector"></param>
    public static void WaitToFindElementHasNotNullText(this WebDriverWait wait, By selector)
    {
        wait.Until(driver => !string.IsNullOrWhiteSpace(driver.FindElement(selector).Text));
    }
    /// <summary>
    ///  Wait to element has text changed
    /// </summary>
    /// <param name="wait"></param>
    /// <param name="oldText"></param>
    /// <param name="selector"></param>
    public static void WaitToElementHasChangeText(this WebDriverWait wait, 
        string oldText,  By selector)
    {
        wait.Until(driver => oldText != driver.FindElement(selector).Text);
    }
}