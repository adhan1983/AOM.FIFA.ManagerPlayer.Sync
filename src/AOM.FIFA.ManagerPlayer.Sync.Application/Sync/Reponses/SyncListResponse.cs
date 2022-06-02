using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Dtos;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Reponses
{
    public class SyncListResponse
    {
        public SyncListResponse()
        {
            Syncs = new List<SyncDto>();
        }

        public List<SyncDto> Syncs { get; set; }
    }
}
