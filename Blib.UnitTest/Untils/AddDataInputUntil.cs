using Blib.UnitTest.Data;
using OpenQA.Selenium;

namespace Blib.UnitTest.Untils;

/// <summary>
/// Helper make find and send data  to element
/// </summary>
public static class AddDataInputUntil
{
    /// <summary>
    ///  Support find element by id and send value for element has found
    /// </summary>
    /// <param name="driver">webdriver </param>
    /// <param name="dataInputModels"> data specific with key and value with key is id and value is data want to send</param>
    public static void AddDataByKeyIdInput(this IWebDriver driver, List<DataInputModel> dataInputModels)
    {
        foreach (var (key, value) in dataInputModels)
        {
            var elementById = driver.FindElement(By.Id(key));
            elementById.SendKeys(key);
        }
    }
}