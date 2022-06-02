using System.Threading.Tasks;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Interfaces.Services
{
    public interface ISourceWithoutSyncService
    {
        Task<bool> ExistSourceWithoutSyncsBySourceId(int sourceId);

        Task<List<int>> GetSourcesWithoutSyncBySourceIdsAsync(List<int> sourceIds);
    }
}
