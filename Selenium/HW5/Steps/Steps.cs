using System.Collections.Generic;
using OpenQA.Selenium;
using HW2.Drivers;
using BusinessLogic.Models;
using BusinessLogic.Services;
using HW2;
using BusinessLogic.Pages;
using NUnit.Allure.Attributes;

namespace Tests.Steps
{
    public class Steps
    {
        public IWebDriver driver;

        public void InitBrowser(string browser = null)
        {
            driver = DriverInstance.GetInstance(browser);
        }
        public void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }

        [AllureStep]
        public void OpenHomePage()
        {
            HomePageObject homePage = new HomePageObject(driver);
            homePage.OpenPage();
        }

        [AllureStep]
        public void Login()
        {
            HomePageObject homePage = new HomePageObject(driver);
            User user = UserCreator.GetUser();
            homePage.Login(user);
        }

        [AllureStep]
        public string GetPageTitle()
        {
            HomePageObject homePage = new HomePageObject(driver);
            return homePage.GetPageTitle();
        }

        [AllureStep]
        public string GetLoggedUserName()
        {
            HomePageObject homePage = new HomePageObject(driver);
            return homePage.GetLoggedUserName();
        }

        [AllureStep]
        public List<string> GetListOfHeaderMenuItems()
        {
            HomePageObject homePage = new HomePageObject(driver);
            return homePage.GetListOfHeaderMenuItems();
        }

        [AllureStep]
        public int GetBenefitIconsCount()
        {
            HomePageObject homePage = new HomePageObject(driver);
            return homePage.GetBenefitIconsCount();
        }

        [AllureStep]
        public List<string> GetListOfBenefitMessages()
        {
            HomePageObject homePage = new HomePageObject(driver);
            return homePage.GetListOfBenefitMessages();
        }

        [AllureStep]
        public bool IsIframeWithFrameButton()
        {
            HomePageObject homePage = new HomePageObject(driver);
            return homePage.IsIframeWithFrameButton();
        }

        [AllureStep]
        public List<string> GetListOfSidebarMenuItems()
        {
            HomePageObject homePage = new HomePageObject(driver);
            return homePage.GetListOfSidebarMenuItems();
        }

        [AllureStep]
        public void GoToDifferentElementsPage()
        {
            HomePageObject homePage = new HomePageObject(driver);
            homePage.GoToDifferentElementsPage();
        }

        [AllureStep]
        public string GetLastLogMessageForSelectedWaterCheckbox()
        {
            DifferentElemetsPageObject elementspage = new DifferentElemetsPageObject(driver);
            elementspage.SelectWaterCheckbox();
            return elementspage.CheckLastLog();
        }

        [AllureStep]
        public string GetLastLogMessageForSelectedWindCheckBox()
        {
            DifferentElemetsPageObject elementspage = new DifferentElemetsPageObject(driver);
            elementspage.SelectWindCheckBox();
            return elementspage.CheckLastLog();
        }

        [AllureStep]
        public string GetLastLogMessageForSelectedSelenRadioButton()
        {
            DifferentElemetsPageObject elementspage = new DifferentElemetsPageObject(driver);
            elementspage.SelectSelenRadioButton();
            return elementspage.CheckLastLog();
        }
    }
}
