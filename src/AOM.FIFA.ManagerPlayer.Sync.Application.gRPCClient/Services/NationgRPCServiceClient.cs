using Grpc.Net.Client;
using gRPCNationClient;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using System;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services
{
    public class NationgRPCServiceClient : INationgRPCServiceClient, IDisposable
    {
        private readonly IGrpcServer _grpcChannelClient;
        private readonly GrpcChannel channel;

        public NationgRPCServiceClient(IGrpcServer grpcChannelClient)
        {
            this._grpcChannelClient = grpcChannelClient;
            channel = GrpcChannel.ForAddress(_grpcChannelClient.EndPoint);            
        }

        public void Dispose()
        {
            channel?.Dispose();
        }
        public async Task<NationReply> InsertNationAsync(NationRequest request)
        {
            var client = new Nation.NationClient(channel);

            var reply = await client.InsertNationAsync(request);

            return reply;

        }
    }
}
