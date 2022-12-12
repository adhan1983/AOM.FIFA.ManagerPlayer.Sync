using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Dtos;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Dtos
{
    public class SyncPageDto
    {
        public int Id { get; set; }
        public int Page { get; set; }
        public int TotalSynchronized { get; set; }
        public int TotalDosNotSynchronized { get; set; }
        public bool SyncPageSuccess { get; set; }
        public int SyncId { get; set; }

        //public int TotalPageSynchronized { get; set; }
        //public int TotalItemsSynchronized { get; set; }
        //public int TotalItensDoNotSynchronized { get; set; }
        //public int SourceIdsDoNotSynchronized { get; set; }
        //public int TotalSyncPageSuccess { get; set; }        
        //public int TotalSyncPageFail { get; set; }
        public List<SourceWithoutSyncDto> SourceWithoutSync { get; set; }
    }
}
