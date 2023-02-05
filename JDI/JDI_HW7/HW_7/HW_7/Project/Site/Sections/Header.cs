using Epam.JDI.Core.Interfaces.Common;
using JDI_Web.Attributes;
using JDI_Web.Selenium.Elements.Complex;
using JDI_Web.Selenium.Elements.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.Project.Site.Sections
{
    public class Header : Section
    {
        [FindBy(XPath = "//img[@src=\"label/Logo_Epam_Color.svg\"]")]
        public IImage Image;

        [FindBy(Css = "ul.uui-navigation.nav")]
        public Menu Menu;
    }
}
