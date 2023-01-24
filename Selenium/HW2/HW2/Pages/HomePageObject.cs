using BusinessLogic.Models;
using BusinessLogic.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW2
{
    public class HomePageObject: AbstractPageObject
    {
        //Поскольку со второй страницы не требцется взаимодействие с общими элементами, 
        //я не стала выносить WebElements в родительский класс или выделять панели в отдельные pageObjects
        public IWebElement DropDownCaretElement => Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//header//li[contains(@class,'uui-profile-menu')]/a")));
        public IWebElement LoginInputField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("name")));
        public IWebElement PasswordInputField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
        public IWebElement EnterButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-button")));
        public IWebElement UserNameLabel => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name")));
        public ICollection<IWebElement> HeaderMenuItems => Wait.Until( d => d.FindElements(By.XPath(".//header//ul[contains(@class,'m-l8')]/li")));
        public ICollection<IWebElement> BenefitItems => Wait.Until(d => d.FindElements(By.XPath(".//div[contains(@class,'benefits')]/div")));
        public string BenefitIcon => "div[@class='benefit']/div[@class='benefit-icon']";
        public string BenefitText => "div[@class='benefit']/span[@class='benefit-txt']";

        public List<IWebElement> IFrameCollection => Wait.Until(d => d.FindElements(By.TagName("iframe"))).ToList();
        public string IFrameButtonId => "frame-button";

        public ICollection<IWebElement> SidebarMenuItems => Wait.Until(d => d.FindElements(By.XPath(".//ul[@class='sidebar-menu left']/li")));
        public IWebElement ServiceSidebarMenuItem => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul/li/a/span[text()='Service']")));
        public IWebElement ServiceMenuDifferentElementsItem => Wait.Until(ExpectedConditions.ElementExists(By.XPath("//ul/li/a/span[text()='Different elements']")));

        private const string url = "https://jdi-testing.github.io/jdi-light/index.html";

        public HomePageObject(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
            Wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void Login(User user)
        {
            DropDownCaretElement.Click();
            LoginInputField.Clear();
            LoginInputField.SendKeys(user.Login);
            PasswordInputField.Clear();
            PasswordInputField.SendKeys(user.Password);
            EnterButton.Click();
        }

        public string GetLoggedUserName()
        {
            return UserNameLabel.Text;
        }

        public List<string> GetListOfHeaderMenuItems()
        {
            List<string> headerItems = new List<string>();
            foreach (var element in HeaderMenuItems)
            {
                headerItems.Add(element.Text);
            }

            return headerItems;
        }

        public int GetBenefitIconsCount()
        {
            int result = 0;
            foreach (var element in BenefitItems)
            {
                try
                {
                    element.FindElement(By.XPath(BenefitIcon));
                }
                catch (NoSuchElementException)
                {
                    continue;
                }

                result++;
            }

            return result;
        }

        public List<string> GetListOfBenefitMessages()
        {
            List<string> result = new List<string>();
            foreach (var element in BenefitItems)
            {
                try
                {
                    result.Add(element.FindElement(By.XPath(BenefitText)).Text);
                }
                catch (NoSuchElementException)
                {
                    continue;
                }
            }

            return result;
        }

        private IWebElement FindIFrameWithButtonElement()
        {
            IWebElement iframe = null;
            foreach (var frame in IFrameCollection)
            {
                try
                {
                    driver.SwitchTo().Frame(frame);
                    driver.FindElement(By.Id(IFrameButtonId));
                    iframe = frame;
                }
                catch (NoSuchElementException)
                {
                    continue;
                }
                finally
                {
                    driver.SwitchTo().ParentFrame();
                }
            }
            return iframe;
        }

        public bool IsIframeWithFrameButton()
        {
            IWebElement frame = FindIFrameWithButtonElement();

            return frame != null;
        }

        public List<string> GetListOfSidebarMenuItems()
        {
            List<string> result = new List<string>();
            foreach (var element in SidebarMenuItems)
            {
                result.Add(element.Text);
            }

            return result;
        }

        public void GoToDifferentElementsPage()
        {
            ServiceSidebarMenuItem.Click();
            ServiceMenuDifferentElementsItem.Click();
        }
    }
}
