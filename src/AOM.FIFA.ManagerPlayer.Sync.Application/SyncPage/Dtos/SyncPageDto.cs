using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Dtos;

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
        public List<SourceWithoutSyncDto> SourceWithoutSync { get; set; }
    }
}
