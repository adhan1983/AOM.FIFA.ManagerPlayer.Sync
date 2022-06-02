using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Dtos
{
    public class SourceWithoutSyncDto
    {
        public SourceWithoutSyncDto() => this.TotalSourceIdPerPage = new List<int>();                
        public List<int> TotalSourceIdPerPage { get; set; }
        public int  SyncPageId { get; set; }
    }
}
