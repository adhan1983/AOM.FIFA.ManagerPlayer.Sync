using AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Gateway.Utils
{
    public class FIFAUrlQueryString : IFIFAUrlQueryString
    {
        public string Page { get; set; }
        public string Limit { get; set; }
    }
}
