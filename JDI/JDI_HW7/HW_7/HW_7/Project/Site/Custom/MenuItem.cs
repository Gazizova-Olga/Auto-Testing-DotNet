using JDI_Web.Selenium.Elements.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.Project.Site.Custom
{
    public class MenuItem : WebElement
    {
        public MenuItem(By byLocator = null)
            : base(byLocator)
        {
        }

        public bool IsSelected()
        {
            return //HasClass("active") &&
                 GetAttribute("ui").Equals("label");
        }
    }
}
