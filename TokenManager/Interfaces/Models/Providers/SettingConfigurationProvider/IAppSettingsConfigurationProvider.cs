using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TokenManager.Interfaces.Models.Providers.SettingConfigurationProvider
{
    public interface IAppSettingsConfigurationProvider
    {
        IConfigurationRoot ConfigSection { get; }
        void CreateConfigurationBuilder();
    }
}