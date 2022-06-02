using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Dtos;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Reponses.Jobs
{
    public class SyncJobResponse
    {
        public SyncJobResponse()
        {
            this.Syncs = new List<SyncDto>();
            
            //this.SourceIdsDoNotSynchronized = new List<int>();
        }

        public List<SyncDto> Syncs { get; set; }

        //public string SyncName { get; set; }
        //public bool AllItemsSynchronized { get; set; }
        //public bool Synchronized { get; set; }
        //public int TotalPagesSynchronized { get; set; }
        //public int TotalItemsSynchronized { get; set; }
        //public int TotalItemDoNotSynchronized { get; set; }
        //public List<int> SourceIdsDoNotSynchronized { get; set; }
    }

}
