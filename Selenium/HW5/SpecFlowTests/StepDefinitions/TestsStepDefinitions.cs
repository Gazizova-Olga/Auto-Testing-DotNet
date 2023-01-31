using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using HW2.Drivers;
using BusinessLogic.Models;
using BusinessLogic.Services;
using HW2;
using BusinessLogic.Pages;
using NUnit.Framework;

namespace SpecFlowTests.StepDefinitions
{
    [Binding]
    public class TestsStepDefinitions
    {
        public IWebDriver driver;

        private readonly ScenarioContext _scenarioContext;

        public TestsStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Before]
        public void InitBrowser()
        {
            driver = DriverInstance.GetInstance();
        }

        [After]
        public void CleanUp()
        {
            DriverInstance.CloseBrowser();
        }

        [Given(@"The browser navigates to '(.*)'")]
        public void BrowserNavidatesTo(string url)
        {
            HomePageObject homePage = new HomePageObject(driver);
            homePage.OpenPage();
        }

        [Then(@"The browser title should be '(.*)'")]
        public void TheBrowserTitleShouldBe(string title)
        {
            Assert.AreEqual(title, (string)_scenarioContext["title"]);
        }

        [When(@"I check the page title")]
        public void ICheckThePageTitle()
        {
            HomePageObject homePage = new HomePageObject(driver);
            _scenarioContext["title"] = homePage.GetPageTitle();
        }

        //public void OpenHomePage()
        //{
        //    HomePageObject homePage = new HomePageObject(driver);
        //    homePage.OpenPage();
        //}

        //public void Login()
        //{
        //    HomePageObject homePage = new HomePageObject(driver);
        //    User user = UserCreator.GetUser();
        //    homePage.Login(user);
        //}

        //public string GetPageTitle()
        //{
        //    HomePageObject homePage = new HomePageObject(driver);
        //    return homePage.GetPageTitle();
        //}

        //public string GetLoggedUserName()
        //{
        //    HomePageObject homePage = new HomePageObject(driver);
        //    return homePage.GetLoggedUserName();
        //}

        //public List<string> GetListOfHeaderMenuItems()
        //{
        //    HomePageObject homePage = new HomePageObject(driver);
        //    return homePage.GetListOfHeaderMenuItems();
        //}

        //public int GetBenefitIconsCount()
        //{
        //    HomePageObject homePage = new HomePageObject(driver);
        //    return homePage.GetBenefitIconsCount();
        //}

        //public List<string> GetListOfBenefitMessages()
        //{
        //    HomePageObject homePage = new HomePageObject(driver);
        //    return homePage.GetListOfBenefitMessages();
        //}

        //public bool IsIframeWithFrameButton()
        //{
        //    HomePageObject homePage = new HomePageObject(driver);
        //    return homePage.IsIframeWithFrameButton();
        //}

        //public List<string> GetListOfSidebarMenuItems()
        //{
        //    HomePageObject homePage = new HomePageObject(driver);
        //    return homePage.GetListOfSidebarMenuItems();
        //}

        //public void GoToDifferentElementsPage()
        //{
        //    HomePageObject homePage = new HomePageObject(driver);
        //    homePage.GoToDifferentElementsPage();
        //}

        //public string GetLastLogMessageForSelectedWaterCheckbox()
        //{
        //    DifferentElemetsPageObject elementspage = new DifferentElemetsPageObject(driver);
        //    elementspage.SelectWaterCheckbox();
        //    return elementspage.CheckLastLog();
        //}

        //public string GetLastLogMessageForSelectedWindCheckBox()
        //{
        //    DifferentElemetsPageObject elementspage = new DifferentElemetsPageObject(driver);
        //    elementspage.SelectWindCheckBox();
        //    return elementspage.CheckLastLog();
        //}

        //public string GetLastLogMessageForSelectedSelenRadioButton()
        //{
        //    DifferentElemetsPageObject elementspage = new DifferentElemetsPageObject(driver);
        //    elementspage.SelectSelenRadioButton();
        //    return elementspage.CheckLastLog();
        //}
    }
}
