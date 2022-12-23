using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Services;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Api.Extensions.ServicesCollectionDependencies
{
    public static class HangFireServiceCollectionExtension
    {
        public static IServiceCollection AddingHangFireServicesDependencies(this IServiceCollection services)
        {
            //services.AddScoped<IJobService, OldJobService>();            
            
            return services;
        }
    }
}
