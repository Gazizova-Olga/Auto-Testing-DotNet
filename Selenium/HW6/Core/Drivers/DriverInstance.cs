using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;
using WebDriverManager.DriverConfigs.Impl;

namespace HW2.Drivers
{
    public class DriverInstance
    {
        private static IWebDriver driver;

        private DriverInstance() 
        {
        }

        public static IWebDriver GetInstance(bool isLocal, string hub, string browser = null)
        {
            if (isLocal)
            {
                if (driver == null)
                {
                    switch (browser)
                    {
                        case "edge":
                            //new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                            driver = new EdgeDriver();
                            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                            driver.Manage().Window.Maximize();
                            return driver;
                        default:
                            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                            var chromeOptions = new ChromeOptions();
                            chromeOptions.AddArgument("--no-sandbox");
                            driver = new ChromeDriver(chromeOptions);
                            driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                            driver.Manage().Window.Maximize();
                            return driver;
                    }
                }
            }
            else
            {
                switch (browser)
                {
                    case "chrome":
                        var options = new ChromeOptions().ToCapabilities();
                        driver = new RemoteWebDriver(new Uri(hub), options, TimeSpan.FromSeconds(180));
                        break;
                    case "edge":
                    default:
                        var optionsEdge = new EdgeOptions().ToCapabilities();
                        driver = new RemoteWebDriver(new Uri(hub), optionsEdge);
                        break;
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

