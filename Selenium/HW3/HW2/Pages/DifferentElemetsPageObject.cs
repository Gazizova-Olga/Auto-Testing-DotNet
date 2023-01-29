using BusinessLogic.Pages.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace BusinessLogic.Pages
{
    public class DifferentElemetsPageObject : AbstractPageObject
    {
        private HeaderMenu header;
        private SideBarMenu sideBar;
        public IWebElement WaterCheckBox => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//label[contains(.,'Water')]")));
        public IWebElement WindCheckBox => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//label[contains(.,'Wind')]")));
        public IWebElement SelenRadioButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//label[contains(.,'Selen')]")));
        public IWebElement LastLogLine => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//section[@class='uui-info-panel-horizontal']/div[contains(@class,'info-panel-body-log')]/div/ul/li[1]")));
        public DifferentElemetsPageObject(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
            Wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            header = new HeaderMenu(browser);
            sideBar = new SideBarMenu(browser);
        }

        public void SelectWaterCheckbox()
        {
            WaterCheckBox.Click();
        }

        public void SelectWindCheckBox()
        {
            WindCheckBox.Click();
        }

        public void SelectSelenRadioButton()
        {
            SelenRadioButton.Click();
        }

        public string CheckLastLog()
        {
            return LastLogLine.Text;
        }
    }
}
