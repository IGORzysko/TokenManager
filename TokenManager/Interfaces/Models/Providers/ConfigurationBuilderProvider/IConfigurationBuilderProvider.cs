using Microsoft.AspNetCore.Hosting;

namespace TokenManager.Interfaces.Models.Providers.ConfigurationBuilderProvider
{
    public interface IConfigurationBuilderProvider
    {
        IWebHostBuilder CreateWebHostBuilder(string configurationJsonFileName);
    }
}
