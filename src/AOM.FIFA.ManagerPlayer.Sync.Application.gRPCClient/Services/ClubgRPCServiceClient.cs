using System;
using gRPCClubClient;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services
{
    public class ClubgRPCServiceClient : BasegRPCServiceClient, IClubgRPCServiceClient, IDisposable
    {
        public ClubgRPCServiceClient(IGrpcServer grpcChannelClient, IDistributeGRPCServiceCache distributeGRPCServiceCache) : base(grpcChannelClient, distributeGRPCServiceCache) { }

        public async Task<ClubReply> InsertClubAsync(ClubRequest request)
        {
            var channel = await CreateAuthorizedChannel();
            
            var client = new Club.ClubClient(channel);

            var reply = await client.InsertClubAsync(request);

            return reply;
        }

        public void Dispose() => channel?.Dispose();
    }
}
