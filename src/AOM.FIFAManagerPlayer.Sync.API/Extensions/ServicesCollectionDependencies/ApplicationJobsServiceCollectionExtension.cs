using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Services;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class ApplicationJobsServiceCollectionExtension
    {
        public static IServiceCollection AddingApplicationJobsDependencies(this IServiceCollection services)
        {
            services.AddScoped<ISyncJobService, SyncJobService>();
            services.AddScoped<ISyncJobLeagueService, SyncJobLeagueService>();
            services.AddScoped<ISyncJobNationService, SyncJobNationService>();
            services.AddScoped<ISyncJobClubService, SyncJobClubService>();
            services.AddScoped<ISyncJobPlayerService, SyncJobPlayerService>();

            return services;
        }
    }
}
