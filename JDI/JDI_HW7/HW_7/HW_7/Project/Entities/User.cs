using Epam.JDI.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_7.Project.Entities
{
    public class User
    {
        public static User DefaultUser = new User("epam", "1234");

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

        [Name("Login")]
        public string Login { get; set; }

        [Name("Password")]
        public string Password { get; set; }
    }

}
