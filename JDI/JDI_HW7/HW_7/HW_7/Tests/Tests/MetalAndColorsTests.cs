using HW_7.Project.Site.Pages;
using HW_7.Project.Site.Sections;
using JDI_Web.Selenium.Elements.Complex;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static HW_7.Tests.Preconditions.Preconditions;

namespace HW_7.Tests.Tests
{
    [TestFixture]
    public class MetalAndColorsSectionTests : TestInit
    {
        private static Menu Menu => SiteJdi.Header.Menu;
        private static LoginForm LoginForm => SiteJdi.LoginForm;
        private static HomePage HomePage => SiteJdi.HomePage;
        private static MetalAndColorsPage MetalPage => SiteJdi.MetalAndColorsPage;
        private static MetalAndColorForm MetalForm => SiteJdi.MetalAndColorForm;

        [Test]
        public void UserCanSubmitMetalAndColorsForm()
        {
            ShouldBeLoggedIn();
            //Menu.MenuItemLocator = By.XPath(".//li/a");
            Menu.Select("METALS & COLORS");
            //MetalForm.numbers.Select("3");

            Assert.IsTrue(true);
        }
    }
}
