using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFAManagerPlayer.Sync.API.Extensions.ServicesCollectionDependencies
{
    public static class GRPCServiceServiceClientCollectionsExtensions
    {
        public static IServiceCollection AddingApplicationgRPCClientDependencies(this IServiceCollection services)
        {
            services.AddScoped<ILeaguegRPCServiceClient, LeaguegRPCServiceClient>();
            services.AddScoped<INationgRPCServiceClient, NationgRPCServiceClient>();
            services.AddScoped<IClubgRPCServiceClient, ClubgRPCServiceClient>();
            services.AddScoped<IPlayergRPCServiceClient, PlayergRPCServiceClient>();            

            return services;
        }
    }
}
