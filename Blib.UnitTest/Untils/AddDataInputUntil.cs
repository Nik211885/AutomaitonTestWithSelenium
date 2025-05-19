using Blib.UnitTest.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
    /// <param name="dataFormModels"></param>
    public static void AddDataListByKeyIdInput(this IWebDriver driver, DataFormInputModel dataFormModels)
    {
        foreach (var dataModel in dataFormModels.DataInputModels)
        {
            driver.AddDataByKeyIdInput(dataModel);
        }
    }

    /// <summary>
    ///     Extension method by web driver send back data input to key id element in dom with value
    /// </summary>
    /// <param name="driver"></param>
    /// <param name="dataInputModel"></param>
    public static void AddDataByKeyIdInput(this IWebDriver driver, DataInputModel dataInputModel)
    {
        var elementById = driver.FindElement(By.Id(dataInputModel.Key));
        if (elementById.TagName.ToLower().Equals("select"))
        {
            var selectElement = new SelectElement(elementById);
            selectElement.SelectByText(dataInputModel.Value);
            return;
        }

        string? inputType = elementById.GetAttribute("type");
        if (inputType != null && inputType.Equals("file", StringComparison.CurrentCultureIgnoreCase))
        {
            var fileUrl = string.Concat(Directory.GetCurrentDirectory(),(@$"/Statics/files/{dataInputModel.Value}"));
            elementById.SendKeys(fileUrl);
            // In this case in all software use one component for upload file
            // so i can just find and send it 
            // In natural in your data you have should provide in button in this action
            // in this case i want to simple ;)) 
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => (d.FindElement(By.Id("imageModal")).GetAttribute("class") ?? "").Contains("show"));
            driver.FindElement(By.Id("btn-crop")).Click();
            driver.FindElement(By.Id("btn-close")).Click();
            return;
        }
        elementById.SendKeys(dataInputModel.Value);
    }
}