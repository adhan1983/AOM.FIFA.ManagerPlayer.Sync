using System.Threading.Tasks;
using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Services
{
    public class SourceWithoutSyncService : ISourceWithoutSyncService
    {
        private readonly ISourceWithoutSyncRepository _sourceWithoutSyncRepository;
        public SourceWithoutSyncService(ISourceWithoutSyncRepository sourceWithoutSyncRepository)
        {
            this._sourceWithoutSyncRepository = sourceWithoutSyncRepository;
        }

        public Task<bool> ExistSourceWithoutSyncsBySourceId(int sourceId)
        {
            return _sourceWithoutSyncRepository.ExistSourceWithoutSyncsBySourceId(sourceId);
        }

        public async Task<List<int>> GetSourcesWithoutSyncBySourceIdsAsync(List<int> sourceIds)
        {
            return await _sourceWithoutSyncRepository.GetSourcesWithoutSyncBySourceIdsAsync(sourceIds);
        }
    }
}
