using Grpc.Net.Client;
using Microsoft.Extensions.Configuration;
using AOM.FIFA.ManagerPlayer.Api.Constants;
using Microsoft.Extensions.DependencyInjection;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;

namespace AOM.FIFAManagerPlayer.Sync.API.Extensions
{
    public static class GrpcChannelExtensions
    {
        public static IServiceCollection AddingGrpcAddress(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddSingleton<IGrpcChannelClient, GrpcClientChannel>(scope =>
            {
                 GrpcClientChannel grpcAddress = new GrpcClientChannel();

                 grpcAddress.Address = configuration.GetValue<string>(ApiConstants.GrpcAddress);

                 return grpcAddress;
            });


            return services;
        }
    }
}
