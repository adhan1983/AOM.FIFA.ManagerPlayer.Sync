using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Dtos;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Dtos
{
    public class SyncDto
    {
        public SyncDto()
        {
            this.SyncPageDto = new SyncPageDto();
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int TotalItemsPerPage { get; set; }
        public bool Synchronized { get; set; }
        public SyncPageDto SyncPageDto { get; set; }
    }
}
