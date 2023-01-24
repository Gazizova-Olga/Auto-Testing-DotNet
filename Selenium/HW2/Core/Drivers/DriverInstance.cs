using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace HW2.Drivers
{
    public class DriverInstance
    {
        private static IWebDriver driver = null;

        private DriverInstance() { }

        public static IWebDriver GetInstance(string browser = null)
        {
            if (driver == null)
            {
                //по какой то причине WebDriverManager подтягивал крайне старую версию 
                //Webdriver, что приводила к ошибке "Сессия не была создана"
                //Поэтому была реализована версия с прямой установкой ChromeDriver
                //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--no-sandbox");
                driver = new ChromeDriver(chromeOptions);
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                driver.Manage().Window.Maximize();
                return driver;
            }

            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}

