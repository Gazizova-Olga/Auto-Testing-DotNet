using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Services
{
    public static class SettingsConfig
    {
        public static IConfiguration config;

        public static IConfiguration GetSettungsConfig()
        {
            if (config == null)
            {
                config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            }

            return config;
        }
    }
}
