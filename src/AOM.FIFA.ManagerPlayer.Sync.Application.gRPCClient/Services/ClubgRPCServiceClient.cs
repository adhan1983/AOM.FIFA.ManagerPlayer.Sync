using System;
using gRPCClubClient;
using Grpc.Net.Client;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services
{
    public class ClubgRPCServiceClient : IClubgRPCServiceClient, IDisposable
    {
        private readonly IGrpcChannelClient _grpcChannelClient;
        private readonly GrpcChannel channel;

        public ClubgRPCServiceClient(IGrpcChannelClient grpcChannelClient)
        {
            this._grpcChannelClient = grpcChannelClient;            
            channel = GrpcChannel.ForAddress(_grpcChannelClient.Address);
        }

        public void Dispose()
        {
            channel?.Dispose();
        }

        public async Task<ClubReply> InsertClubAsync(ClubRequest request)
        {   
            var client = new Club.ClubClient(channel);

            var reply = await client.InsertClubAsync(request);

            return reply;
        }
    }
}
