using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Api.Constants;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AOM.FIFAManagerPlayer.Sync.API.Extensions.ServicesCollectionDependencies
{
    public static class AuthenticationDependencies
    {
        public static IServiceCollection AddingAuthenticationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.
                AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>{                               
                    options.Authority = configuration.GetValue<string>(ApiConstants.Auth0PropertiesDomain);
                    options.Audience = configuration.GetValue<string>(ApiConstants.Auth0PropertiesAudience);
                    options.RequireHttpsMetadata = false;
                });

            return services;
        }

    }
}
