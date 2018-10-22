using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using TokenManager.Models.Providers.ConfigurationBuilderProvider;
using TokenManager.Models.Providers.SettingConfiguration;

namespace TokenManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
