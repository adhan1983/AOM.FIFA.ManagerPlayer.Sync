namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Utils.Interfaces
{
    public interface IAuth0Properties
    {
        string Domain { get; set; }

        string ClientId { get; set; }

        string ClientSecret { get; set; }

        string Audience { get; set; }
    }
}
