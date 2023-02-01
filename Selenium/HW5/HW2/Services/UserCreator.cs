using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public static class UserCreator
    {
        private static string login =>/* SettingsConfig.GetSettungsConfig()["login"] ??*/ "Roman";
        private static string password = /*SettingsConfig.GetSettungsConfig()["password"] ??*/ "Jdi1234";

        public static User GetUser()
        {
            return new User(login, password);
        }
    }
}
