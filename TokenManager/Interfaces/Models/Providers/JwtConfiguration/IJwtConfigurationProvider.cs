using Microsoft.AspNetCore.Hosting;

namespace TokenManager.Interfaces.Models.Providers.JwtConfiguration
{
    public interface IJwtConfigurationProvider
    {
        string GetSecretKey();
        string GetExpirationTimeInMinutes();
    }
}