namespace TokenManager.Interfaces.Models.Providers
{
    public interface IJwtConfigurationProvider
    {
        string GetSecretKey();
        string GetExpirationTimeInMinutes();
    }
}
