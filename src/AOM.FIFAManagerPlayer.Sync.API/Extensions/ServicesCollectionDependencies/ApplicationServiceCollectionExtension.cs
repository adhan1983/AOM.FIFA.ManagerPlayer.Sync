using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Services;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Services;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Interfaces.Services;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class ApplicationServiceCollectionExtension
    {
        public static IServiceCollection AddingApplicationDependencies(this IServiceCollection services)
        {
                        
            services.AddScoped<ISyncService, SyncService>();
            services.AddScoped<ISourceWithoutSyncService, SourceWithoutSyncService>();

            return services;
        }
    }
}
