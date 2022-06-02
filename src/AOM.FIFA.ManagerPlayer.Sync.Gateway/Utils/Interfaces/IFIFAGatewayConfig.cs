namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces
{
    public interface IFIFAGatewayConfig
    {
        string FIFAApiKey { get; set; }

        string FIFAApiToken { get; set; }

        string FIFAClient { get; set; }
    }
}
