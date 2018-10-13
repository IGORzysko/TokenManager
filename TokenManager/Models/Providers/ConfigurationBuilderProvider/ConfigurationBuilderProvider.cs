using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using TokenManager.Interfaces.Models.Providers.JwtConfigurationProvider;

namespace TokenManager.Models.Providers.ConfigurationBuilderProvider
{
    public class JwtConfigurationProvider : IJwtConfigurationProvider
    {
        private IConfigurationRoot ConfigSection { get; set; }

        public JwtConfigurationProvider()
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

        public string GetSecretKey()
        {
            return this.ConfigSection.GetSection("jwt").GetValue<string>("secretKey");
        }

        public string GetExpirationTimeInMinutes()
        {
            return this.ConfigSection.GetSection("jwt").GetValue<string>("expirationTimeInMinutes");
        }
    }
}