using HW_7.Project.Entities;
using JDI_Web.Attributes;
using JDI_Web.Selenium.Elements.Complex;
using JDI_Web.Selenium.Elements.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace HW_7.Project.Site.Sections
{
    public class MetalAndColorForm : Form<MetalAndColorsData>
    {
        [FindBy(Css = ".radio")]
        public RadioButtons numbers;

        [FindBy(XPath = "//*[text()='Submit']")]
        public Button submit;
    }
}
