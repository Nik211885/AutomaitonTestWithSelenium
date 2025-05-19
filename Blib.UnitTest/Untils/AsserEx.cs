using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Blib.UnitTest.Untils;

public static class AsserEx
{
    /// <summary>
    ///     Check toast waring selector message has equals message
    ///     if message null just check message toast not null
    /// </summary>
    /// <param name="webDriver"></param>
    /// <param name="message"></param>
    public static void ToastWaringWithMessage(IWebDriver webDriver, string? message = null)
    {
        var textMessage = webDriver.FindElement(ToastSelector.ToastWaring).Text;
        if (message is null)
        {
            Assert.NotEmpty(textMessage);
        }
        Assert.Equal(webDriver.FindElement(ToastSelector.ToastWaring).Text, message);
    }
    /// <summary>
    ///     Check toast info selector message has equals message
    ///     if message null just check message toast not null
    /// </summary>
    /// <param name="webDriver"></param>
    /// <param name="message"></param>

    public static void ToastInfoWithMessage(IWebDriver webDriver, string? message = null)
    {
        var textMessage = webDriver.FindElement(ToastSelector.ToastInfo).Text;
        if (message is null)
        {
            Assert.NotEmpty(textMessage);
        }
        Assert.Equal(webDriver.FindElement(ToastSelector.ToastInfo).Text, message);
    }
    /// <summary>
    ///     Check toast success selector message has equals message
    ///     if message null just check message toast not null
    /// </summary>
    /// <param name="webDriver"></param>
    /// <param name="message"></param>
    public static void ToastSuccessWithMessage(IWebDriver webDriver, string? message = null)
    {
        var  textMessage = webDriver.FindElement(ToastSelector.ToastSuccess).Text;
        if (message is null)
        {
            Assert.NotEmpty(textMessage);
        }
        Assert.Equal(webDriver.FindElement(ToastSelector.ToastSuccess).Text, message);
    }
    /// <summary>
    ///     Check toast danger selector message has equals message
    ///     if message null just check message toast not null
    /// </summary>
    /// <param name="webDriver"></param>
    /// <param name="message"></param>
    public static void ToastDangerWithMessage(IWebDriver webDriver, string? message = null)
    {
        var  textMessage = webDriver.FindElement(ToastSelector.ToastDanger).Text;
        if (message is null)
        {
            Assert.NotEmpty(textMessage);
        }
        Assert.Equal(webDriver.FindElement(ToastSelector.ToastDanger).Text, message);
    }
}