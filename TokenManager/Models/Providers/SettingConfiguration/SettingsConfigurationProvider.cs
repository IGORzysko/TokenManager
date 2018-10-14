using Microsoft.Extensions.Configuration;
using System.IO;
using TokenManager.Interfaces.Models.Providers.SettingConfigurationProvider;

namespace TokenManager.Models.Providers.SettingConfiguration
{
    public class SettingsConfigurationProvider : ISettingsConfigurationProvider
    {
        public IConfigurationRoot ConfigSection { get; private set; }
        public string ConfigirationFileName { get; private set; }

        public SettingsConfigurationProvider()
        {
            this.CreateConfigurationBuilder();
        }

        public void SetConfigurationFileName(string configurationFileName)
        {
            this.ConfigirationFileName = configurationFileName;
        }

        public void CreateConfigurationBuilder()
        {
            this.ConfigSection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(this.ConfigirationFileName, optional: true, reloadOnChange: true)
                .Build();
        }
    }
}