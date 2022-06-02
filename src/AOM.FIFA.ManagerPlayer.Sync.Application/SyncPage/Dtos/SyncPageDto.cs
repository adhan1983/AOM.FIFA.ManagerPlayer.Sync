using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Dtos;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Dtos
{
    public class SyncPageDto
    {
        public SyncPageDto()
        {
            this.SourceIdsWithoutSync = new List<SourceWithoutSyncDto>();
        }        
        public int TotalPageSynchronized { get; set; }
        public int TotalItemsSynchronized { get; set; }
        public int TotalItensDoNotSynchronized { get; set; }
        public int SourceIdsDoNotSynchronized { get; set; }
        public int TotalSyncPageSuccess { get; set; }        
        public int TotalSyncPageFail { get; set; }
        public List<SourceWithoutSyncDto> SourceIdsWithoutSync { get; set; }
    }
}
