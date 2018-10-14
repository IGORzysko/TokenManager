using Microsoft.Extensions.Configuration;
using TokenManager.Interfaces.Models.Providers.JwtConfiguration;
using TokenManager.Interfaces.Models.Providers.SettingConfigurationProvider;

namespace TokenManager.Models.Providers.ConfigurationBuilderProvider
{
    public class JwtConfigurationProvider : IJwtConfigurationProvider
    {
        private ISettingsConfigurationProvider _settingsConfigurationProvider { get; set; }

        public JwtConfigurationProvider(ISettingsConfigurationProvider settingsConfigurationProvider)
        {
            _settingsConfigurationProvider = settingsConfigurationProvider;
        }

        public string GetSecretKey()
        {
            return _settingsConfigurationProvider.ConfigSection.GetSection("jwt")
                .GetValue<string>("secretKey");
        }

        public string GetExpirationTimeInMinutes()
        {
            return _settingsConfigurationProvider.ConfigSection.GetSection("jwt")
                .GetValue<string>("expirationTimeInMinutes");
        }
    }
}