using System;
using System.Threading.Tasks;
using TokenManager.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using TokenManager.Interfaces.Models.Providers;

namespace TokenManager.Services
{
    public class TokenManager : ITokenManager
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtConfigurationProvider _jwtConfigurationProvider;

        public TokenManager (IDistributedCache cache, 
                    IHttpContextAccessor httpContextAccessor,
                    IJwtConfigurationProvider jwtConfigurationProvider)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _jwtConfigurationProvider = jwtConfigurationProvider;
        }

        public async Task DeactivateAsync(string token)
        {
            await _cache.SetStringAsync(GetKey(token), " "
                , new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(
                        double.Parse(_jwtConfigurationProvider.GetExpirationTimeInMinutes()))
                });
        }

        public async Task DeactivateCurrentAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> IsActiveAsync(string token)
        {
            return await _cache.GetStringAsync(GetKey(token)) == null;
        }

        public async Task<bool> IsCurrentTokenActiveAsync()
        {
            throw new NotImplementedException();
        }

        private static string GetKey(string token)
        {
            return $"tokens: {token} are deactivated";
        }
    }
}
