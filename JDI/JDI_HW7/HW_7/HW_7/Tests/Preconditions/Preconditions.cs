using HW_7.Project.Entities;
using JDI_Web.Selenium.Elements.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HW_7.Tests.TestInit;

namespace HW_7.Tests.Preconditions
{
    public class Preconditions
    {
        public static void ShouldBeLoggedIn()
        {
            if (!WebPage.GetUrl().Contains("https://epam.github.io/JDI/"))
                SiteJdi.HomePage.Open();
            if (!SiteJdi.UserName.Displayed)
                Login();
        }

        public static void Login()
        {
            SiteJdi.UserIcon.Click();
            SiteJdi.LoginForm.Submit(User.DefaultUser, "enter");
        }

        public static void ShouldBeLoggedOut()
        {
            if (!SiteJdi.HomePage.Url.Contains("https://epam.github.io/JDI/"))
                SiteJdi.HomePage.Open();
            if (SiteJdi.UserName.Displayed)
                Logout();
        }

        public static void Logout()
        {
            SiteJdi.UserIcon.Click();
            SiteJdi.Logout.Click();
        }
    }
}
