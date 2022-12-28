using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Api.Constants;
using AOM.FIFA.ManagerPlayer.Gateway.Utils;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces;

namespace AOM.FIFAManagerPlayer.Sync.API.Extensions
{
    public static class Auth0Dependencies
    {
        public static IServiceCollection AddingAuth0Dependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddSingleton<IAuth0Properties, Auth0Properties>(scope =>
            {
                var auth0Settings = configuration.GetSection(ApiConstants.Auth0Properties);

                Auth0Properties auth0Properties = new Auth0Properties();

                auth0Properties.Domain = auth0Settings.GetValue<string>("Domain");
                auth0Properties.ClientSecret = auth0Settings.GetValue<string>("ClientSecret");
                auth0Properties.ClientId = auth0Settings.GetValue<string>("ClientId");
                auth0Properties.Audience = auth0Settings.GetValue<string>("Audience");
                auth0Properties.GrantType = auth0Settings.GetValue<string>("GrantType");
                auth0Properties.UrlToken = auth0Settings.GetValue<string>("UrlToken");

                return auth0Properties;
            });
            
            return services;
        }
    }
}
