namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces
{
    public interface IFIFAManager
    {
        string BaseAddress { get; set; }
        string Club { get; set; }
        string Player { get; set; }
        string Nation { get; set; }
        string League { get; set; }
    }
}
