using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services
{
    public class DistributeGRPCServiceCache : IDistributeGRPCServiceCache
    {
        private IMemoryCache _cache;
        private readonly IHttpClientFactoryService _httpClientFactoryService;
        public DistributeGRPCServiceCache(IMemoryCache cache, IHttpClientFactoryService httpClientFactoryService)
        {            
            _cache = cache ?? throw new ArgumentNullException(nameof(cache)); ;            
            _httpClientFactoryService = httpClientFactoryService ?? throw new ArgumentNullException(nameof(httpClientFactoryService));
        }

        public async Task<string> GetAccessToken()
        {           
            var tokenCache = _cache.Get("token");
            
            if (tokenCache == null) 
            {
                var responseToken = await _httpClientFactoryService.GetTokenAsync();                
                
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                                       .SetSlidingExpiration(TimeSpan.FromDays(60))
                                       .SetAbsoluteExpiration(TimeSpan.FromDays(70))
                                       .SetPriority(CacheItemPriority.Normal)
                                       .SetSize(1024);
                _cache.Set("token", responseToken.access_token, cacheEntryOptions);

                return responseToken.access_token;
                
            }

            return tokenCache.ToString();

        }       
    }
}
