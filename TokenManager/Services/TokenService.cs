using System;
using System.Threading.Tasks;
using TokenManager.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using TokenManager.Interfaces.Models.Providers.JwtConfiguration;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace TokenManager.Services
{
    public class TokenService : ITokenService
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtConfigurationProvider _jwtConfigurationProvider;

        public TokenService (IDistributedCache cache, 
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
            this.DeactivateAsync(this.GetCurrentTokenAsync());
        }

        public async Task<bool> IsActiveAsync(string token)
        {
            return await _cache.GetStringAsync(GetKey(token)) == null;
        }
        
        public async Task<bool> IsCurrentTokenActiveAsync()
        {
            return await this.IsActiveAsync(this.GetCurrentTokenAsync());
        }

        #region helper methods

        private string GetCurrentTokenAsync()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext
                .Request.Headers["authorization"];

            return authorizationHeader == StringValues.Empty 
                ? string.Empty 
                : authorizationHeader.Single().Split(" ").Last();
        }

        private static string GetKey(string token)
        {
            return $"tokens: {token} are deactivated";
        }

        #endregion
    }
}
