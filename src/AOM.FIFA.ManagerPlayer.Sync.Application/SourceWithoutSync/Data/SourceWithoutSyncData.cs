using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data
{
    public class SourceWithoutSyncData
    {
        public int Id { get; set; }
        public int SourceId { get; set; }
        public int SyncPageId { get; set; }
        public SyncPageData SyncPage { get; set; }
    }
}
