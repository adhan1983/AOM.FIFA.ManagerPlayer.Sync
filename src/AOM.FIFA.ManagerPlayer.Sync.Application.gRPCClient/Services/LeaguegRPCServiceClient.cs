using System;
using gRPCLeagueClient;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services
{
    public class LeaguegRPCServiceClient : BasegRPCServiceClient, ILeaguegRPCServiceClient, IDisposable
    {
        public LeaguegRPCServiceClient(IGrpcServer grpcChannelClient, IDistributeGRPCServiceCache distributeGRPCServiceCache) : base(grpcChannelClient, distributeGRPCServiceCache) { }

        public async Task<LeagueReply> InsertLeagueAsync(LeagueRequest request)
        {
            var channel = await CreateAuthorizedChannel();

            var client = new League.LeagueClient(channel);

            var reply = await client.InsertLeagueAsync(request);

            return reply;
        }

        public void Dispose() => channel?.Dispose();
    }
}
