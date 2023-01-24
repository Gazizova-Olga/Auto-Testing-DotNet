using OpenQA.Selenium;
using HW2.Drivers;
using HW2;

namespace Steps
{
    public class Steps
    {
        public IWebDriver driver;

        public void InitBrowser(string browser = null)
        {
            driver = DriverInstance.GetInstance(browser);
        }
        public void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }

        public HomePageObject OpenInitialHomePage()
        {
            HomePageObject homepage = new HomePageObject(driver);
            homepage.OpenPage();
            return homepage;
        }
    }
}
