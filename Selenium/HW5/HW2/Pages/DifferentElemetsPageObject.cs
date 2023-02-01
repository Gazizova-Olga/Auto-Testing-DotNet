using BusinessLogic.Pages.Components;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace BusinessLogic.Pages
{
    public class DifferentElemetsPageObject
    {
        private HeaderMenu header;
        private SideBarMenu sideBar;
        private LogBar logBar;
        private readonly IWebDriver driver;
        public WebDriverWait Wait { get; set; }
        public IWebElement WaterCheckBox => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//label[contains(.,'Water')]")));
        public IWebElement WindCheckBox => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//label[contains(.,'Wind')]")));
        private string chosenElement = ".//label[contains(.,'{0}')]";
        public IWebElement SelenRadioButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//label[contains(.,'Selen')]")));
        public IWebElement ColorDropDown => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//select[@class='uui-form-element']")));
        private string colorFormat = ".//select[@class='uui-form-element']/option[text()='{0}']";

        public DifferentElemetsPageObject(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
            Wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            header = new HeaderMenu(browser);
            sideBar = new SideBarMenu(browser);
            logBar = new LogBar(browser);
        }

        public void SelectWaterCheckbox()
        {
            WaterCheckBox.Click();
        }

        public void SelectWindCheckBox()
        {
            WindCheckBox.Click();
        }

        public void SelectMetalRadioButton(string element = "Selen")
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(chosenElement, element)))).Click();
        }

        public string CheckNumberLogLine(int number = 1)
        {
            return logBar.CheckLastLog(number);
        }

        public bool SelectElementCheckBox(string element)
        {
            IWebElement checkBox = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(chosenElement, element))));
            checkBox.Click();
            return checkBox.Selected;
        }

        public void OpenColorList()
        {
            ColorDropDown.Click();
        }

        public void ChooseColorFromDropDownList(string color)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(colorFormat, color)))).Click();
        }
    }
}
