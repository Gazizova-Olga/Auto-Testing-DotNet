using BusinessLogic.Models;
using BusinessLogic.Pages;
using BusinessLogic.Pages.Components;
using BusinessLogic.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HW2
{
    public class HomePageObject
    {
        private HeaderMenu header;
        private SideBarMenu sideBar;
        private readonly IWebDriver driver;
        public WebDriverWait Wait { get; set; }
        public ICollection<IWebElement> BenefitItems => Wait.Until(d => d.FindElements(By.XPath(".//div[contains(@class,'benefits')]/div")));
        public string BenefitIcon => "div[@class='benefit']/div[@class='benefit-icon']";
        public string BenefitText => "div[@class='benefit']/span[@class='benefit-txt']";
        public List<IWebElement> IFrameCollection => Wait.Until(d => d.FindElements(By.TagName("iframe"))).ToList();
        public string IFrameButtonId => "frame-button";

        private string url => SettingsConfig.GetSettungsConfig()["homePageUrl"];

        public HomePageObject(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
            Wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            header = new HeaderMenu(browser);
            sideBar = new SideBarMenu(browser);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public string GetPageTitle()
        {
            return driver.Title;
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
             return sideBar.GetListOfSidebarMenuItems();
        }

        public void GoToDifferentElementsPage()
        {
            sideBar.GoToDifferentElementsPage();
        }

        public void Login(User user)
        {
            header.Login(user);
        }

        public string GetLoggedUserName()
        {
            return header.GetLoggedUserName();
        }

        public List<string> GetListOfHeaderMenuItems()
        {
            return header.GetListOfHeaderMenuItems();
        }
    }
}
