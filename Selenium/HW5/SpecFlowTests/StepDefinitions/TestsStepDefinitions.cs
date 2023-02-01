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
using TechTalk.SpecFlow.Assist;
using SpecFlow.Assist;

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
            _scenarioContext.Clear();
            DriverInstance.CloseBrowser();
        }

        [Given(@"I open JDI GitHub site")]
        public void IOpenJDIGitHubSite()
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

        [When(@"I login into site as user '([^']*)'")]
        public void WhenILoginIntoSiteAsUser(string p0)
        {
            HomePageObject homePage = new HomePageObject(driver);
            User user = UserCreator.GetUser();
            homePage.Login(user);
        }


        [Then(@"The logged user name shoul be '([^']*)'")]
        public void TheLoggedUserNameShoulBe(string name)
        {
            HomePageObject homePage = new HomePageObject(driver);
            Assert.AreEqual(name, homePage.GetLoggedUserName());
        }

        [Given(@"I login as user '(.*)'")]
        public void ILoginAsUser(string p0)
        {
            HomePageObject homePage = new HomePageObject(driver);
            User user = UserCreator.GetUser();
            homePage.Login(user);
        }

        [Given(@"I click on '(.*)' button in Header")]
        [When(@"I click on '(.*)' button in Header")]
        public void IClickOnButtonInHeader(string button)
        {
            HomePageObject homePage = new HomePageObject(driver);
            homePage.OpenServiceDropDownMenuu();
        }

        [Given(@"I click on '(.*)' button in Service dropdown")]
        [When(@"I click on '(.*)' button in Service dropdown")]
        public void IClickOnButtonInServiceDropdown(string p0)
        {
            HomePageObject homePage = new HomePageObject(driver);
            homePage.ClickOnDropDownMenuItem(p0);
        }

        [When(@"I select (.*) checkbox")]
        public void ISelectElementCheckbox(string element)
        {
            DifferentElemetsPageObject elemetsPageObject = new DifferentElemetsPageObject(driver);
            _scenarioContext[element] = elemetsPageObject.SelectElementCheckBox(element);
        }

        [Then(@"The last log line should contain (.*)")]
        public void TheLastLogLineShouldContainMessage(string message)
        {
            DifferentElemetsPageObject elemetsPageObject = new DifferentElemetsPageObject(driver);
            string actual = elemetsPageObject.CheckNumberLogLine();
            Assert.That(actual, Does.Contain(message));
        }

        [Then(@"The selected state of (.*) checkbox should be (.*)")]
        public void ThenTheSelectedStateOfWaterCheckboxShouldBe(string element, string state)
        {
            Assert.AreEqual(_scenarioContext[element], state);
        }

        [When(@"I select '(.*)' checkbox for '(.*)'")]
        public void ISelectCheckboxFor(string vip, string userName)
        {
            UserTablePageObject userTable = new UserTablePageObject(driver);
            userTable.SelectUserCheckBoxName(vip, userName);
        }

        [Then(@"(.*) log row has (.*) text in log section")]
        public void LogRowHasTextInLogSection(int number, string message)
        {
            UserTablePageObject userTable = new UserTablePageObject(driver);
            string actual = userTable.CheckNumberLogLine(number);
            Assert.That(actual, Does.Contain(message));
        }

        [When(@"I select (.*) radiobutton")]
        public void ISelectRadiobutton(string metal)
        {
            DifferentElemetsPageObject elementsPage = new DifferentElemetsPageObject(driver);
            elementsPage.SelectMetalRadioButton();
            _scenarioContext["metal"] = elementsPage.CheckNumberLogLine();
        }

        [Given(@"I click on color field")]
        public void IClickOnColorField()
        {
            DifferentElemetsPageObject elementsPage = new DifferentElemetsPageObject(driver);
            elementsPage.OpenColorList();
        }

        [When(@"I select '(.*)' in the dropdown list")]
        public void WhenISelectInTheDropdownList(string color)
        {
            DifferentElemetsPageObject elementsPage = new DifferentElemetsPageObject(driver);
            elementsPage.ChooseColorFromDropDownList(color);
        }

        [Then(@"'(.*)' page should be opened")]
        public void ThenPageShouldBeOpened(string pageTitle)
        {
            UserTablePageObject userTable = new UserTablePageObject(driver);
            Assert.AreEqual(userTable.GetPageTitle(), pageTitle);
        }

        [Then(@"(.*) Number Type Dropdowns should be displayed on Users Table on User Table Page")]
        public void ThenNumberTypeDropdownsShouldBeDisplayedOnUsersTableOnUserTablePage(int count)
        {
            UserTablePageObject userTable = new UserTablePageObject(driver);
            int actual = userTable.GetCountOfDropDowns();
            Assert.AreEqual(count, actual);
        }

        [Then(@"(.*) Usernames should be displayed on Users Table on User Table Page")]
        public void ThenUsernamesShouldBeDisplayedOnUsersTableOnUserTablePage(int count)
        {
            UserTablePageObject userTable = new UserTablePageObject(driver);
            int actual = userTable.GetCountOfRegisteredUsers();
            Assert.AreEqual(count, actual);
        }

        [Then(@"(.*) Description texts under images should be displayed on Users Table on User Table Page")]
        public void ThenDescriptionTextsUnderImagesShouldBeDisplayedOnUsersTableOnUserTablePage(int expected)
        {
            UserTablePageObject userTable = new UserTablePageObject(driver);
            int actual = userTable.GetCountOfDescription();
            Assert.AreEqual(actual, expected);
        }

        [Then(@"(.*) checkboxes should be displayed on Users Table on User Table Page")]
        public void ThenCheckboxesShouldBeDisplayedOnUsersTableOnUserTablePage(int expected)
        {
            UserTablePageObject userTable = new UserTablePageObject(driver);
            int actual = userTable.GetCountOfCheckBoxes();
            Assert.AreEqual(actual, expected);
        }

        [Then(@"User table should contain following values:")]
        public void ThenUserTableShouldContainFollowingValues(Table table)
        {
            var collection = new List<RegisteredUser>();
            foreach (var row in table.Rows)
            {
                collection.Add(new RegisteredUser(int.Parse(row["Number"]), row["User"], @row["Description"]));
            }

            UserTablePageObject userTable = new UserTablePageObject(driver);
            List<RegisteredUser> actual = userTable.CheckListOfRegisteredUsers();
            Assert.IsTrue(collection.SequenceEqual(actual));
        }

        [Then(@"droplist should contain values in column Type for user Roman")]
        public void ThenDroplistShouldContainValuesInColumnTypeForUserRoman(Table table)
        {
            var collection = new List<string>();
            foreach (var row in table.Rows)
            {
                collection.Add(row.Values.First());
            }
            UserTablePageObject userTable = new UserTablePageObject(driver);
            List<string> actual = userTable.GetDropDownListItemsForUser("Roman");
            Assert.AreEqual(collection, actual);
        }
    }
}
