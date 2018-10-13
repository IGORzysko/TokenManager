using System.Configuration;
using TokenManager.Interfaces.Models.Providers.JwtConfigurationProvider;

namespace TokenManager.Services.Providers
{
    public class JwtConfigurationProvider : IJwtConfigurationProvider
    {

        public JwtConfigurationProvider()
        {
            
        }

        public string GetSecretKey()
        {
            return ConfigurationManager.AppSettings["jwt:secretKey"];
        }

        public string GetExpirationTimeInMinutes()
        {
            return ConfigurationManager.AppSettings["jwt:expirationTimeInMinutes"];
        }
    }
}