using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data
{
    public class SyncPageData
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public int TotalSynchronized { get; set; }
        public int TotalDosNotSynchronized { get; set; }
        public bool SyncPageSuccess { get; set; }
        public int SyncId { get; set; }
        public SyncData Sync { get; set; }
        public List<SourceWithoutSyncData> SourcesWithoutSync { get; set; }
    }
}
