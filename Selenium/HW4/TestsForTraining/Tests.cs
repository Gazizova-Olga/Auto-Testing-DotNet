using BusinessLogic.Models;
using BusinessLogic.Pages;
using BusinessLogic.Services;
using FluentAssertions;
using FluentAssertions.Execution;
using HW2;
using HW2.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Allure.Core;

namespace Tests
{
    [TestFixture]
    [AllureNUnit]
    public class Tests
    {
        private IWebDriver driver;
        private IConfiguration config;


        [SetUp]
        public void Init()
        {
            config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            string browser = config["browser"];
            driver = DriverInstance.GetInstance(browser);
        }

        [TearDown]
        public void Cleanup()
        {
            DriverInstance.CloseBrowser();
        }

        [Test]
        public void EX1()
        {
            //expected results
            const string expectedTitle = "Home Page";
            const string expectedUserName = "ROMAN IOVLEV";
            const int expectedCountHeaderMenuItems = 4;
            List<string> expectedHeaderItems = new List<string> { "HOME", "CONTACT FORM", "SERVICE", "METALS & COLORS" };
            const int expectedIconsCount = 4;
            const int expectedMessagesCount = 4;
            List<string> expectedListOfBenefitMessages = new List<string> {
                "To include good practices\r\nand ideas from successful\r\nEPAM project",
                "To be flexible and\r\ncustomizable",
                "To be multiplatform",
                "Already have good base\r\n(about 20 internal and\r\nsome external projects),\r\nwish to get more…" };
            List<string> expectedSidebarMenuItems = new List<string> { 
                "Home",
                "Contact form", 
                "Service", 
                "Metals & Colors",
                "Elements packs" };

            //1 step. Open test site by URL
            HomePageObject homePage = new HomePageObject(driver);
            homePage.OpenPage();

            //2 step. Assert Browser title
            string title = homePage.GetPageTitle();

            //3 step. Perform login
            User user = UserCreator.GetUser();
            homePage.Login(user);

            //4 step. Assert Username is loggined
            string userName = homePage.GetLoggedUserName();

            //5 step. Assert that there are 4 items on the header section are displayed and they have proper texts
            List<string> headerItems = homePage.GetListOfHeaderMenuItems();

            //6 step. Assert that there are 4 images on the Index Page and they are displayed
            int iconsItems = homePage.GetBenefitIconsCount();

            //7 step. Assert that there are 4 texts on the Index Page under icons and they have proper text
            List<string> messagesList = homePage.GetListOfBenefitMessages();

            //8,9,10 step. Assert that there is the iframe with “Frame Button” exist
            //Switch to the iframe and check that there is “Frame Button” in the iframe
            //Switch to original window back
            bool isFrameWithButton = homePage.IsIframeWithFrameButton();

            //11 step. Assert that there are 5 items in the Left Section are displayed and they have proper text
            List<string> sidebarMenuItems = homePage.GetListOfSidebarMenuItems();

            using (new AssertionScope())
            {
                title.Should().Be(expectedTitle);
                userName.Should().Be(expectedUserName);
                headerItems.Count.Should().Be(expectedCountHeaderMenuItems);
                headerItems.Should().BeEquivalentTo(expectedHeaderItems);
                iconsItems.Should().Be(expectedIconsCount);
                messagesList.Count.Should().Be(expectedMessagesCount);
                messagesList.Should().BeEquivalentTo(expectedListOfBenefitMessages);
                isFrameWithButton.Should().Be(true);
                sidebarMenuItems.Should().BeEquivalentTo(expectedSidebarMenuItems);
            }
        }

        [Test]
        public void EX2()
        {
            //expected results
            const string expectedTitle = "Home Page";
            const string expectedUserName = "ROMAN IOVLEV";
            const string expectedWaterLog = "Water: condition changed to true";
            const string expectedWindLog = "Wind: condition changed to true";
            const string expectedSelenLog = "metal: value changed to Selen";

            //1 step. Open test site by URL
            HomePageObject homePage = new HomePageObject(driver);
            homePage.OpenPage();

            //2 step. Assert Browser title
            string title = homePage.GetPageTitle();

            //3 step. Perform login
            User user = UserCreator.GetUser();
            homePage.Login(user);

            //4 step. Assert Username is loggined
            string userName = homePage.GetLoggedUserName();

            //5 step.Open through the header menu Service -> Different Elements Page
            homePage.GoToDifferentElementsPage();
            DifferentElemetsPageObject elementspage = new DifferentElemetsPageObject(driver);

            //6 step. Select checkboxes
            elementspage.SelectWaterCheckbox();
            string waterLog = elementspage.CheckLastLog();

            elementspage.SelectWindCheckBox();
            string windLog = elementspage.CheckLastLog();

            elementspage.SelectSelenRadioButton();
            string selenLog = elementspage.CheckLastLog();

            using (new AssertionScope())
            {
                title.Should().Be(expectedTitle);
                userName.Should().Be(expectedUserName);
                waterLog.Should().Contain(expectedWaterLog);
                windLog.Should().Contain(expectedWindLog);
                selenLog.Should().Contain(expectedSelenLog);
            }
        }
    }
}
