using AOM.FIFA.ManagerPlayer.Api.Constants;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AOM.FIFAManagerPlayer.Sync.API.Extensions
{
    public static class GrpcDependencies
    {
        public static IServiceCollection AddingGrpcDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IGrpcServer, GrpcServer>(scope =>
            {
                 GrpcServer grpcAddress = new GrpcServer();

                 grpcAddress.EndPoint = configuration.GetValue<string>(ApiConstants.Address);

                 return grpcAddress;
            });

            return services;
        }
    }
}
