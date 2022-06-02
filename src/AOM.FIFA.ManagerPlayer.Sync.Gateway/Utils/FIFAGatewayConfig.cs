using AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Gateway.Utils
{
    public class FIFAGatewayConfig : IFIFAGatewayConfig
    {
        public string FIFAApiKey { get; set; }
        public string FIFAApiToken { get; set; }
        public string FIFAClient { get; set; }
    }
}
