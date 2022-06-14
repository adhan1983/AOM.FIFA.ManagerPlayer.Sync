using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils
{
    public class GrpcServer : IGrpcServer
    {
        public string EndPoint { get; set; }
        
    }
}
