using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Pages.Components
{
    public class SideBarMenu : AbstractPageObject
    {
        public ICollection<IWebElement> SidebarMenuItems => Wait.Until(d => d.FindElements(By.XPath(".//ul[@class='sidebar-menu left']/li")));
        public IWebElement ServiceSidebarMenuItem => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//ul/li/a/span[text()='Service']")));
        public IWebElement ServiceMenuDifferentElementsItem => Wait.Until(ExpectedConditions.ElementExists(By.XPath("//ul/li/a/span[text()='Different elements']")));

        public SideBarMenu(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
            Wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
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
