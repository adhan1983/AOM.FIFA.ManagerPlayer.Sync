using AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Gateway.Utils
{
    public class FIFAUrl : IFIFAUrl
    {
        public string league { get; set; }
        public string player { get; set; }
        public string nation { get; set; }
        public string club { get; set; }
        public string page { get; set; }
        public string limit { get; set; }
    }
}
