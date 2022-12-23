using Hangfire;
using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Api.Constants;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFAManagerPlayer.Sync.API.Extensions
{
    public static class HangFireDependencies
    {
        public static IServiceCollection AddingHangiFideDependencies(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddHangfire(config =>
            {
                config.UseSqlServerStorage(configuration.GetConnectionString(ApiConstants.SqlHangFireConectionString));
            });
            
            services.AddHangfireServer();

            return services;
        }
    }
}
