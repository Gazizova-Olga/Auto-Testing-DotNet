using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace BusinessLogic.Pages.Components
{
    public class LogBar
    {
        public WebDriverWait Wait { get; set; }
        private readonly IWebDriver driver;
        private string logLine = ".//section[@class='uui-info-panel-horizontal']/div[contains(@class,'info-panel-body-log')]/div/ul/li[{0}]";

        public LogBar(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
            Wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
        }

        public string CheckLastLog(int number)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(logLine, number)))).Text;
        }
    }
}
