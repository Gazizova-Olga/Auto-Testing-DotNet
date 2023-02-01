﻿using AngleSharp.Dom;
using BusinessLogic.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Pages.Components
{
    public class HeaderMenu 
    {
        public WebDriverWait Wait { get; set; }
        private readonly IWebDriver driver;
        public IWebElement DropDownCaretElement => Wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//header//li[contains(@class,'uui-profile-menu')]/a")));
        public IWebElement LoginInputField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("name")));
        public IWebElement PasswordInputField => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("password")));
        public IWebElement EnterButton => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("login-button")));
        public IWebElement UserNameLabel => Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("user-name")));
        public ICollection<IWebElement> HeaderMenuItems => Wait.Until(d => d.FindElements(By.XPath(".//header//ul[contains(@class,'m-l8')]/li")));
        public IWebElement ServiceMenuItem => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//header//ul[contains(@class,'m-l8')]/li[@class='dropdown']")));
        public IWebElement DifferentElementsDropdownMenuItem => Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(".//header//li[contains(@class,'dropdown')]//li/a[text()='Different elements']")));
        private string dropDownMenuItem = ".//header//ul[contains(@class,'m-l8')]//ul[@class='dropdown-menu']/li/a[text()='{0}']";

        public HeaderMenu(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
            Wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
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

        public void GoToDifferentElementsPage()
        {
            ServiceMenuItem.Click();
            DifferentElementsDropdownMenuItem.Click();
        }

        public void OpenServiceDropDownMenu()
        {
            ServiceMenuItem.Click();
        }

        public void ClickOnDropDownMenuItem(string text)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(dropDownMenuItem, text)))).Click();
        }
    }
}
