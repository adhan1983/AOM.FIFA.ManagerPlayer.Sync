using System;
using Grpc.Net.Client;
using gRPCPlayerClient;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services
{
    public class PlayergRPCServiceClient : IPlayergRPCServiceClient, IDisposable
    {
        private readonly IGrpcChannelClient _grpcChannelClient;
        private readonly GrpcChannel channel;
        public PlayergRPCServiceClient(IGrpcChannelClient grpcChannelClient)
        {
            this._grpcChannelClient = grpcChannelClient;
            channel = GrpcChannel.ForAddress(_grpcChannelClient.Address);
        }
        public void Dispose()
        {
            channel?.Dispose();
        }
        public async Task<PlayerReply> InsertPlayerAsync(PlayerRequest request)
        {                     
            var client = new Player.PlayerClient(channel);

            var reply = await client.InsertPlayerAsync(request);

            return reply;
        }
    }
}
