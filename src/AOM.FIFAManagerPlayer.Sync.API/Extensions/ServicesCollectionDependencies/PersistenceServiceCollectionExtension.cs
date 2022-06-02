using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Persistence.Repository;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class PersistenceServiceCollectionExtension
    {
        public static IServiceCollection AddingPersistenceDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISyncRepository, SyncRepository>();
            services.AddScoped<ISourceWithoutSyncRepository, SourceWithoutSyncRepository>();
            
            return services;
        }
    }
}
