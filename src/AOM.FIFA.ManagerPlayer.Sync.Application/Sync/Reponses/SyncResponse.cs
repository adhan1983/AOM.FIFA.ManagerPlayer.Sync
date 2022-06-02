using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Dtos;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Reponses
{
    public class SyncResponse
    {
        public SyncResponse()
        {
            Sync = new SyncDto();
        }
        public SyncDto Sync { get; set; }
    }
}
