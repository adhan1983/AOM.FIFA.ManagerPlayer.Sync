using AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Gateway.Utils
{
    public class FIFAManager : IFIFAManager
    {
        public string BaseAddress { get; set; }
        public string Club { get; set; }
        public string Player { get; set; }
        public string Nation { get; set; }
        public string League { get; set; }
    }
}
