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
                ToastSelector.ToastSuccess,
                ToastSelector.ToastDanger,
                ToastSelector.ToastInfo,
                ToastSelector.ToastWaring
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
        wait.Until(driver => driver.FindElement(ToastSelector.ToastSuccess).Text == (message));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="wait"></param>
    /// <param name="message"></param>
    public static void WaitToToastWaring(this WebDriverWait wait, string message)
    {
        wait.Until(driver => driver.FindElement(ToastSelector.ToastWaring).Text.Equals(message));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="wait"></param>
    /// <param name="message"></param>
    public static void WaitToToastInfo(this WebDriverWait wait, string message)
    {
        wait.Until(driver => driver.FindElement(ToastSelector.ToastInfo).Text.Equals(message));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="wait"></param>
    /// <param name="message"></param>
    public static void WaitToToastDanger(this WebDriverWait wait, string message)
    {
        wait.Until(driver => driver.FindElement(ToastSelector.ToastDanger).Text.Equals(message));
    }
}