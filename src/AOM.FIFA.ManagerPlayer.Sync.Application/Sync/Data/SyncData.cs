using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data
{
    public class SyncData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemsPerPage { get; set; }
        public bool Synchronized { get; set; }
        public List<SyncPageData> SyncPages { get; set; }
    }
}
