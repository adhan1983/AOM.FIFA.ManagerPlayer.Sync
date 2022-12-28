using Grpc.Core;
using Grpc.Net.Client;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Base
{

    public class BasegRPCServiceClient 
    {
        private readonly IGrpcServer _grpcChannelClient;        
        public readonly GrpcChannel channel;
        private readonly IDistributeGRPCServiceCache _distributeGRPCServiceCache;

        public BasegRPCServiceClient(IGrpcServer grpcChannelClient, IDistributeGRPCServiceCache distributeGRPCServiceCache)
        {
            _grpcChannelClient = grpcChannelClient;            
            channel = GrpcChannel.ForAddress(_grpcChannelClient.EndPoint);
            _distributeGRPCServiceCache = distributeGRPCServiceCache;        
        }

        public async Task<GrpcChannel> CreateAuthorizedChannel()
        {
            var accessToken = await _distributeGRPCServiceCache.GetAccessToken();

            var credentials = CallCredentials.FromInterceptor((context, metadata) =>
            {
                if (!string.IsNullOrEmpty(accessToken))
                {
                    metadata.Add("Authorization", $"Bearer {accessToken}");
                }
                return Task.CompletedTask;
            });

            var channel = GrpcChannel.ForAddress(_grpcChannelClient.EndPoint, new GrpcChannelOptions
            {
                Credentials = ChannelCredentials.Create(new SslCredentials(), credentials)
            });

            return channel;
        }              
    }
}
