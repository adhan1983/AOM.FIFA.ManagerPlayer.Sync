using AOM.FIFA.ManagerPlayer.Api.Constants;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions
{
    public static class HangFireDependencies
    {
        public static IServiceCollection AddingHangFireDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            var strConnection = configuration.GetConnectionString(ApiConstants.SqlHangFireConectionString);

            services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(strConnection, new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                QueuePollInterval = TimeSpan.Zero,
                UseRecommendedIsolationLevel = true,
                DisableGlobalLocks = true
            }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();


            return services;
        }
    }
}
