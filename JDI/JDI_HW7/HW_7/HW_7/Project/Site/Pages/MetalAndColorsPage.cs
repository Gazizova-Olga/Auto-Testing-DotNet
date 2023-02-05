using HW_7.Project.Site.Sections;
using JDI_Web.Attributes;
using JDI_Web.Selenium.Elements.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.Project.Site.Pages
{
    [Page(Url = "/metals-colors.html", Title = "Metals & Colors")]
    public class MetalAndColorsPage : WebPage
    {
        [FindBy(Css = ".main-content")]
        public MetalAndColorForm metalAndColorForm;
    }
}
