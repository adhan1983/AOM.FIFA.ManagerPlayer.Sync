using Microsoft.EntityFrameworkCore;
using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;
using AOM.FIFA.ManagerPlayer.Sync.Persistence.Configuration;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data;


namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Context
{
    public class FIFASyncDbContext : DbContext
    {
        public FIFASyncDbContext(DbContextOptions<FIFASyncDbContext> options) : base(options)
        {

        }

        public DbSet<SyncData> SyncData { get; set; }

        public DbSet<SyncPageData> SyncPage { get; set; }

        public DbSet<SourceWithoutSyncData> SourceWithoutSync { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new SyncDataConfiguration());
            modelBuilder.ApplyConfiguration(new SyncPageDataConfiguration());
            modelBuilder.ApplyConfiguration(new SourceWithoutSyncDataConfiguration());
        }
    }
}
