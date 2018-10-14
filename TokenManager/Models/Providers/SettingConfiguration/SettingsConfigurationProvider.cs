using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using TokenManager.Interfaces.Models.Providers.SettingConfigurationProvider;

namespace TokenManager.Models.Providers.SettingConfiguration
{
    public class SettingsConfigurationProvider : ISettingsConfigurationProvider
    {
        public IConfigurationRoot ConfigSection { get; private set; }

        public SettingsConfigurationProvider()
        {

        }

        public IWebHostBuilder CreateWebHostBuilder()
        {
            this.ConfigSection = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            return WebHost.CreateDefaultBuilder()
                .UseConfiguration(this.ConfigSection)
                .UseStartup<Startup>();
        }

        public void RunWebHostBuilder()
        {
            CreateWebHostBuilder().Build().Run();
        }
    }
}
