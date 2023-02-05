using HW_7.Project.Site.Pages;
using HW_7.Project.Site.Sections;
using JDI_Web.Attributes;
using JDI_Web.Selenium.Elements.Composite;
using OpenQA.Selenium;
using System.Web.UI.WebControls;

namespace HW_7.Project.Site
{
    [Site(Domain = "https://epam.github.io/JDI")]
    public class SiteJdi : WebSite
    {
        [Page(Url = "/index.html", Title = "Home Page")]
        public HomePage HomePage;

        [Page(Url = "/metals-colors.html", Title = "Metals & Colors")]
        public MetalAndColorsPage MetalAndColorsPage;

        [FindBy(Css = ".uui-main-container page-inside")]
        public MetalAndColorForm MetalAndColorForm;

        [FindBy(Id = "login-form")]
        public LoginForm LoginForm;

        [FindBy(Css = ".profile-photo [ui=label]")]
        public IWebElement UserName;

        [FindBy(Css = ".fa-sign-out")]
        public IWebElement Logout;

        [FindBy(Css = "img#user-icon")]
        public IWebElement UserIcon;

        [FindBy(Css = ".sidebar-menu")]
        public Menu LeftMenu;

        [FindBy(Css = ".uui-header")]
        public Header Header;

    }
}
