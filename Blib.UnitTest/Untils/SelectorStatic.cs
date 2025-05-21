using OpenQA.Selenium;

namespace Blib.UnitTest.Untils;

public static class SelectorStatic
{
    public static By ToastWaring = By.Id("solidwarningToastContent");
    public static By ToastInfo = By.Id("solidinfoToastContent");
    public static By ToastSuccess = By.Id("solidsuccessToastContent");
    public static By ToastDanger = By.Id("soliddangerToastContent");

    public static By LoadModal = By.Id("loaderModal");
}