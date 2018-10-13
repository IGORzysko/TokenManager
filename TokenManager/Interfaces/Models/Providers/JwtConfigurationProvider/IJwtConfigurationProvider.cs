namespace TokenManager.Interfaces.Models.Providers.JwtConfigurationProvider
{
    public interface IJwtConfigurationProvider
    {
        string GetSecretKey();
        string GetExpirationTimeInMinutes();
    }
}
