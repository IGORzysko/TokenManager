using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using TokenManager.Interfaces.Models.Providers.ConfigurationBuilderProvider;

namespace TokenManager.Models.Providers.ConfigurationBuilderProvider
{
    public class ConfigurationBuilderProvider : IConfigurationBuilderProvider
    {
        public IConfigurationRoot Config { get; private set; }

        public ConfigurationBuilderProvider()
        {
            //CreateWebHostBuilder("appsettings.json").Build().Run();
        }

        public IWebHostBuilder CreateWebHostBuilder (string configurationJsonFileName)
        {
            this.Config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(configurationJsonFileName, optional: true, reloadOnChange: true)
                .Build();

            return WebHost.CreateDefaultBuilder()
                .UseConfiguration(this.Config)
                .UseStartup<Startup>();
        }

        public string GetKeyValue (string jwtKey)
        {
            return this.Config.GetValue<string>($"jwt:{jwtKey}");
        }
    }
}
