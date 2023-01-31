using FluentAssertions;
using FluentAssertions.Execution;
using HW2.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using NUnit.Allure.Core;
using System.IO;
using System;
using NUnit.Framework.Interfaces;
using NUnit.Allure.Attributes;
using Allure.Commons;

namespace Tests
{
    [TestFixture]
    [AllureNUnit]
    public class Tests
    {
        //private IConfiguration config;
        private Steps.Steps steps = new Steps.Steps();

        [SetUp]
        public void Init()
        {
            //config = new ConfigurationBuilder()
            //.AddJsonFile("appsettings.json")
            //.Build();

            //path = new DirectoryInfo(config["path"]);
            //string browser = config["browser"];

            steps.InitBrowser(/*browser*/);
        }

        [TearDown]
        public void Cleanup()
        {
            TakeScreenShots();
            DriverInstance.CloseBrowser();
        }

        private void TakeScreenShots()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                byte[] content = (steps.driver as ITakesScreenshot).GetScreenshot().AsByteArray;
                DateTime time = DateTime.Now;
                string dateToday = "_date_" + time.ToString("yyyy-MM-dd") + "_time_" + time.ToString("HH-mm-ss");
                AllureLifecycle.Instance.AddAttachment(dateToday, "image/png", content);
            }
        }

        [Test]
        [AllureDescription("Check of login process and composition of home page: header menu, sidebar menu, index and main area")]
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
            steps.OpenHomePage();

            //2 step. Assert Browser title
            string title = steps.GetPageTitle();

            //3 step. Perform login
            steps.Login();

            //4 step. Assert Username is loggined
            string userName = steps.GetLoggedUserName();

            //5 step. Assert that there are 4 items on the header section are displayed and they have proper texts
            List<string> headerItems = steps.GetListOfHeaderMenuItems();

            //6 step. Assert that there are 4 images on the Index Page and they are displayed
            int iconsItems = steps.GetBenefitIconsCount();

            //7 step. Assert that there are 4 texts on the Index Page under icons and they have proper text
            List<string> messagesList = steps.GetListOfBenefitMessages();

            //8,9,10 step. Assert that there is the iframe with “Frame Button” exist
            //Switch to the iframe and check that there is “Frame Button” in the iframe
            //Switch to original window back
            bool isFrameWithButton = steps.IsIframeWithFrameButton();

            //11 step. Assert that there are 5 items in the Left Section are displayed and they have proper text
            List<string> sidebarMenuItems = steps.GetListOfSidebarMenuItems();

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
        [AllureDescription("Check of login process and work of different element page: wind and wated check boxes," +
            " selen radio button, log field")]
        public void EX2()
        {
            //expected results
            const string expectedTitle = "Home Page";
            const string expectedUserName = "ROMAN IOVLEV";
            const string expectedWaterLog = "Water: condition changed to true";
            const string expectedWindLog = "Wind: condition changed to true";
            const string expectedSelenLog = "metal: value changed to Selen";

            //1 step. Open test site by URL
            steps.OpenHomePage();

            //2 step. Assert Browser title
            string title = steps.GetPageTitle();

            //3 step. Perform login
            steps.Login();

            //4 step. Assert Username is loggined
            string userName = steps.GetLoggedUserName();

            //5 step.Open through the header menu Service -> Different Elements Page
            steps.GoToDifferentElementsPage();

            //6 step. Select checkboxes
            string waterLog = steps.GetLastLogMessageForSelectedWaterCheckbox();

            string windLog = steps.GetLastLogMessageForSelectedWindCheckBox();

            string selenLog = steps.GetLastLogMessageForSelectedSelenRadioButton();

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
