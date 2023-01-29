using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public static class UserCreator
    {
        private static string login => SettingsConfig.GetSettungsConfig()["login"];
        private static string password = SettingsConfig.GetSettungsConfig()["password"];

        public static User GetUser()
        {
            return new User(login, password);
        }
    }
}
