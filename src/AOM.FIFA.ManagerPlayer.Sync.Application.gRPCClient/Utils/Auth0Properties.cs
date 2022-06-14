using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils
{
    public class Auth0Properties : IAuth0Properties
    {
        public string Domain { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Audience { get; set; }
    }
}
