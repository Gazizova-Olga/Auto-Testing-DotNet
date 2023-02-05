using Epam.JDI.Core.Attributes;
using Epam.JDI.Core.Interfaces.Common;
using HW_7.Project.Entities;
using JDI_Web.Attributes;
using JDI_Web.Selenium.Elements.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.Project.Site.Sections
{
    public class LoginForm : Form<User>
    {
        [FindBy(Css = "button.btn-login")]
        [Name("Login")]
        public IButton LoginButton;

        [FindBy(Css = "#name")]
        [Name("Login")]
        public ITextField LoginField;

        [FindBy(Css = "#password")]
        [Name("Password")]
        public ITextField PasswordField;
    }
}
