﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace TokenManager.Interfaces.Models.Providers.SettingConfigurationProvider
{
    public interface ISettingsConfigurationProvider
    {
        IConfigurationRoot ConfigSection { get; }
        IWebHostBuilder CreateWebHostBuilder();
        void RunWebHostBuilder();
    }
}