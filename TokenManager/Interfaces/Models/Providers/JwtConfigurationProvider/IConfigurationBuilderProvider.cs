using Microsoft.AspNetCore.Hosting;

namespace TokenManager.Interfaces.Models.Providers.JwtConfigurationProvider
{
    public interface IJwtConfigurationProvider
    {
        IWebHostBuilder CreateWebHostBuilder();
        void RunWebHostBuilder();
    }
}