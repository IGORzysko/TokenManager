using Microsoft.Extensions.Configuration;
using System.IO;
using TokenManager.Interfaces.Models.Providers.SettingConfigurationProvider;

namespace TokenManager.Models.Providers.SettingConfiguration
{
    public class AppSettingsConfigurationProvider : IAppSettingsConfigurationProvider
    {
        public IConfigurationRoot ConfigSection { get; private set; }

        public AppSettingsConfigurationProvider()
        {
            this.CreateConfigurationBuilder();
        }

        public void CreateConfigurationBuilder()
        {
            this.ConfigSection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}