using BusinessLogic.Models;
using BusinessLogic.Pages;
using BusinessLogic.Pages.Components;
using BusinessLogic.Services;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogic.Pages
{
    public class UserTablePageObject
    {
        private LogBar logBar;
        private readonly IWebDriver driver;
        public WebDriverWait Wait { get; set; }
        private string tableRowByName = "//*[@id='user-table']/tbody/tr[td/a[text()='{0}']]";
        private string checkBox = "td//label[text()='{0}']";
        private string dropDownList = ".//select/option";
        private string numberInRow = ".//td[1]";
        private string nameInRow = ".//td//a[@href]";
        private string descriptionInRow = ".//div[@class='user-descr']/span";
        public ICollection<IWebElement> DropDownLists => Wait.Until(d => d.FindElements(By.XPath(".//select")));
        public ICollection<IWebElement> RegisteredUserList => Wait.Until(d => d.FindElements(By.XPath(".//*[@id='user-table']//a[@href]")));
        public ICollection<IWebElement> DescriptionList => Wait.Until(d => d.FindElements(By.XPath(".//*[@id='user-table']//div[@class='user-descr']/span")));
        public ICollection<IWebElement> CheckboxList => Wait.Until(d => d.FindElements(By.XPath(".//*[@id='user-table']//input[@type='checkbox']")));
        public ICollection<IWebElement> TableRows => Wait.Until(d => d.FindElements(By.XPath("//*[@id='user-table']/tbody/tr")));

        public UserTablePageObject(IWebDriver browser)
        {
            driver = browser;
            PageFactory.InitElements(browser, this);
            Wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            logBar = new LogBar(browser);
        }

        public void SelectUserCheckBoxName(string checkboxName, string name)
        {
            IWebElement row = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(string.Format(tableRowByName, name))));
            row.FindElement(By.XPath(string.Format(checkBox, checkboxName))).Click();
        }

        public string CheckNumberLogLine(int number = 1)
        {
            return logBar.CheckLastLog(number);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public int GetCountOfDropDowns()
        {
            return DropDownLists.Count;
        }

        public int GetCountOfRegisteredUsers()
        {
            return RegisteredUserList.Count;
        }

        public int GetCountOfDescription()
        {
            return DescriptionList.Count;
        }

        public int GetCountOfCheckBoxes()
        {
            return CheckboxList.Count;
        }

        public List<string> GetDropDownListItemsForUser(string name)
        {
            ICollection<IWebElement> items = driver.FindElements(By.XPath(string.Format(tableRowByName, name) + dropDownList));
            List<string> result = new List<string>();
            foreach (IWebElement item in items)
            {
                result.Add(item.Text);
            }

            return result;
        }

        public List<RegisteredUser> CheckListOfRegisteredUsers()
        {
            List<RegisteredUser> result = new List<RegisteredUser>();
            List<string> test= new List<string>();
            List<IWebElement> rows = TableRows.ToList();
            foreach (var row in rows)
            {
                string number = row.FindElement(By.XPath(numberInRow)).Text;
                test.Add(number);
            }


                foreach (var row in TableRows)
            {
                int number = int.Parse(row.FindElement(By.XPath(numberInRow)).Text);
                string name = row.FindElement(By.XPath(nameInRow)).Text;
                string description = row.FindElement(By.XPath(descriptionInRow)).Text;
                
                result.Add(new RegisteredUser(number, name, description));
            }

            return result;
        }
    }
}
