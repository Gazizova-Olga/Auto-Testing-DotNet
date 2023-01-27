using BusinessLogic.Models;

namespace BusinessLogic.Services
{
    public static class UserCreator
    {
        private const string login = "Roman";
        private const string password = "Jdi1234";

        public static User GetUser()
        {
            return new User(login, password);
        }
    }
}
