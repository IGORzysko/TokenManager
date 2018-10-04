using System;
using System.Threading.Tasks;
using TokenManager.Interfaces.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace TokenManager.Services
{
    public class TokenManager : ITokenManager
    {
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOptions<JwtOptions> _jwtOptions;

        public TokenManager (IDistributedCache cache, 
                    IHttpContextAccessor httpContextAccessor, 
                    IOptions<JwtOptions> jwtOptions)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _jwtOptions = jwtOptions;
        }

        public async Task ITokenManager.DeactivateAsync(string token)
        {
            throw new NotImplementedException();
        }

        public async Task ITokenManager.DeactivateCurrentAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ITokenManager.IsActiveAsync(string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ITokenManager.IsCurrentTokenActiveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
