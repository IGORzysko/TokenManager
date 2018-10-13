using Microsoft.AspNetCore.Hosting;

namespace TokenManager.Interfaces.Models.Providers
{
    public interface ISettingsConfigurationProvider
    {
        IWebHostBuilder CreateWebHostBuilder();
        void RunWebHostBuilder();
    }
}