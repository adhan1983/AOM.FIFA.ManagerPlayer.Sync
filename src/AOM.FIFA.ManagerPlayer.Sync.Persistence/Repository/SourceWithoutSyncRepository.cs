using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AOM.FIFA.ManagerPlayer.Sync.Persistence.Base;
using AOM.FIFA.ManagerPlayer.Sync.Persistence.Context;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Repository
{
    public class SourceWithoutSyncRepository : Repository<SourceWithoutSyncData>, ISourceWithoutSyncRepository
    {
        public SourceWithoutSyncRepository(FIFASyncDbContext fifaSyncDbContext) : base(fifaSyncDbContext) { }

        public async Task<bool> ExistSourceWithoutSyncsBySourceId(int sourceId)
        {
            
            return await this._fifaSyncDbContext.
                                SourceWithoutSync.
                                FirstOrDefaultAsync(x => x.SourceId == sourceId) != null ? true : false;            
        }

        public async Task<List<int>> GetSourcesWithoutSyncBySourceIdsAsync(List<int> sourceIds)
        {
            var models = await this._fifaSyncDbContext.
                                    SourceWithoutSync.
                                    Where(x => sourceIds.Contains(x.SourceId)).
                                    Select(x => x.SourceId).
                                    ToListAsync();

            return models;

        }
    }
}
