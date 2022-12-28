using System;
using gRPCNationClient;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services
{
    public class NationgRPCServiceClient : BasegRPCServiceClient, INationgRPCServiceClient, IDisposable
    {                
        public NationgRPCServiceClient(IGrpcServer grpcChannelClient, IDistributeGRPCServiceCache distributeGRPCServiceCache) : base(grpcChannelClient, distributeGRPCServiceCache) { }
        public async Task<NationReply> InsertNationAsync(NationRequest request)
        {
            var channel = await CreateAuthorizedChannel();
            
            var client = new Nation.NationClient(channel);

            var reply = await client.InsertNationAsync(request);

            return reply;

        }        
        public void Dispose() => channel?.Dispose();
    }
}
