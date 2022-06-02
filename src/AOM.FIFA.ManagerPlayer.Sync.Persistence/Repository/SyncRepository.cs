using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Sync.Persistence.Base;
using AOM.FIFA.ManagerPlayer.Sync.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Repository
{
    public class SyncRepository : Repository<SyncData>, ISyncRepository
    {
        public SyncRepository(FIFASyncDbContext dbContext) : base(dbContext) { }

        public async Task<SyncData> GetSyncByNameAsync(string name)
        {
            var model = await this._fifaSyncDbContext.
                                SyncData.
                                    Include(a => a.SyncPages).
                                    ThenInclude(b => b.SourcesWithoutSync).
                                FirstOrDefaultAsync(a => a.Name == name);

            return model;
        }

        public async Task<List<SyncData>> GetAllSyncDatawithIncludeAsync()
        {
            var models = await this._fifaSyncDbContext.
                                    SyncData.
                                    Include(a => a.SyncPages).
                                    ThenInclude(b => b.SourcesWithoutSync).
                                    ToListAsync();


            return models;
        }
    }
}
