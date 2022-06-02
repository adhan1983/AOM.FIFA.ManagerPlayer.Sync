using System.Threading.Tasks;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Interfaces.Repositories
{
    public interface ISourceWithoutSyncRepository
    {
        Task<bool> ExistSourceWithoutSyncsBySourceId(int sourceId);

        Task<List<int>> GetSourcesWithoutSyncBySourceIdsAsync(List<int> sourceIds);
    }
}
