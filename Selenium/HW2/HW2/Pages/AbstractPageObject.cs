using HW2.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BusinessLogic.Pages
{
    public class AbstractPageObject
    {
        public WebDriverWait Wait { get; set; }
        protected IWebDriver driver;

        public void InitBrowser(string browser = null)
        {
            driver = DriverInstance.GetInstance(browser);
        }
        public void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }
    }
}
