using Grpc.Net.Client;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces
{
    public interface IGrpcChannelClient
    {
       string Address { get; set; }
    }
}
