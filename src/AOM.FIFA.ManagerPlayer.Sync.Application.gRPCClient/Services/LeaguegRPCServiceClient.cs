using Grpc.Net.Client;
using gRPCLeagueClient;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;
using System;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services
{
    public class LeaguegRPCServiceClient : ILeaguegRPCServiceClient, IDisposable
    {
        private readonly IGrpcServer _grpcChannelClient;
        private readonly GrpcChannel channel;

        public LeaguegRPCServiceClient(IGrpcServer grpcChannelClient)
        {
            this._grpcChannelClient = grpcChannelClient;
            channel = GrpcChannel.ForAddress(_grpcChannelClient.EndPoint);
        }

        public void Dispose()
        {
            channel?.Dispose();
        }

        public async Task<LeagueReply> InsertLeagueAsync(LeagueRequest request)
        {
            var client = new League.LeagueClient(channel);

            var reply = await client.InsertLeagueAsync(request);

            return reply;
        }
    }
}
