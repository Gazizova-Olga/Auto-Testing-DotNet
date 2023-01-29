using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using WebDriverManager.DriverConfigs.Impl;

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
                switch (browser)
                {
                    case "chrome":
                        //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        var chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--no-sandbox");
                        driver = new ChromeDriver(chromeOptions);
                        driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                        driver.Manage().Window.Maximize();
                        return driver;
                    default:
                        //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                        driver = new EdgeDriver();
                        driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                        driver.Manage().Window.Maximize();
                        return driver;
                }
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

