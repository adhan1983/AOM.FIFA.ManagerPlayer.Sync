namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces
{
    public interface IAuth0Properties
    {
        string Domain { get; set; }

        string ClientId { get; set; }

        string ClientSecret { get; set; }

        string Audience { get; set; }

        public string GrantType { get; set; }
        
        public string UrlToken { get; set; }
    }
}
