using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils
{
    public class GrpcClientChannel : IGrpcChannelClient
    {
        public string Address { get; set; }
    }
}
