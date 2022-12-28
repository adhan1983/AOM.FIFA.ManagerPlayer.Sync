using System;
using gRPCPlayerClient;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services
{
    public class PlayergRPCServiceClient : BasegRPCServiceClient, IPlayergRPCServiceClient, IDisposable
    {              
        public PlayergRPCServiceClient(IGrpcServer grpcChannelClient, IDistributeGRPCServiceCache distributeGRPCServiceCache) : base(grpcChannelClient, distributeGRPCServiceCache) { }
     
        public async Task<PlayerReply> InsertPlayerAsync(PlayerRequest request)
        {
            var channel = await CreateAuthorizedChannel();

            var client = new Player.PlayerClient(channel);
            
            var reply = await client.InsertPlayerAsync(request);

            return reply;
        }
        public void Dispose() => channel?.Dispose();
    }
}
