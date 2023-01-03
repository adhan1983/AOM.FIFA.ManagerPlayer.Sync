using System;
using System.Linq;
using Hangfire.Dashboard;
using System.IdentityModel.Tokens.Jwt;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;

namespace AOM.FIFAManagerPlayer.Sync.API.Extensions
{
    public class HangfireDashboardJwtAuthorizationFilter : IDashboardAuthorizationFilter
    {
        private readonly IHttpClientFactoryService _httpClientFactoryService;
        public HangfireDashboardJwtAuthorizationFilter(IHttpClientFactoryService httpClientFactoryService) => _httpClientFactoryService = httpClientFactoryService;

        public bool Authorize(DashboardContext context)
        {   
            var token = _httpClientFactoryService.GetAccessToken();

            var httpContext = context.GetHttpContext();         

            if (String.IsNullOrEmpty(token.Result))
            {
                return false;
            }

            var handler = new JwtSecurityTokenHandler();
            
            var jwtSecurityToken = handler.ReadJwtToken(token.Result);

            return jwtSecurityToken.Claims.Any(t => t.Type == "iss" && t.Value == "https://dev-qy3r1fvm5flnafx8.us.auth0.com/");
        }
    }
}
