using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.Base.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Repositories
{
    public interface ISyncRepository : IRepository<SyncData>
    {
        Task<SyncData> GetSyncByIdAsync(int id);
        Task<List<SyncData>> GetAllSyncDatawithIncludeAsync();
    }
}
