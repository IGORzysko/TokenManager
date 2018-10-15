using Microsoft.Extensions.Configuration;
using TokenManager.Interfaces.Models.Providers.JwtConfiguration;
using TokenManager.Interfaces.Models.Providers.SettingConfigurationProvider;

namespace TokenManager.Models.Providers.ConfigurationBuilderProvider
{
    public class JwtConfigurationProvider : IJwtConfigurationProvider
    {
        private ISettingsConfigurationProvider SettingsConfigurationProvider { get; set; }

        public JwtConfigurationProvider(ISettingsConfigurationProvider settingsConfigurationProvider)
        {
            SettingsConfigurationProvider = settingsConfigurationProvider;
        }

        public string GetSecretKey()
        {
            return SettingsConfigurationProvider.ConfigSection.GetSection("jwt")
                .GetValue<string>("secretKey");
        }

        public string GetExpirationTimeInMinutes()
        {
            return SettingsConfigurationProvider.ConfigSection.GetSection("jwt")
                .GetValue<string>("expirationTimeInMinutes");
        }
    }
}