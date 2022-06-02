using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Configuration
{
    public class SourceWithoutSyncDataConfiguration : IEntityTypeConfiguration<SourceWithoutSyncData>
    {
        public void Configure(EntityTypeBuilder<SourceWithoutSyncData> builder)
        {
            builder.
               ToTable(nameof(SourceWithoutSyncData)).
               HasKey(x => x.Id);
            builder.
                Property(x => x.SourceId).
                IsRequired();
            builder.
                Property(x => x.SyncPageId).
                IsRequired();
        }
    }
}
