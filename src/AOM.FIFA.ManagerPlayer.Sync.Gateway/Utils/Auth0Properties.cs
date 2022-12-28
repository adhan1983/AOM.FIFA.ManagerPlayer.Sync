using AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Gateway.Utils
{
    public class Auth0Properties : IAuth0Properties
    {
        public string Domain { get; set; }

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string Audience { get; set; }

        public string GrantType { get; set; }

        public string UrlToken { get; set; }
    }
}
