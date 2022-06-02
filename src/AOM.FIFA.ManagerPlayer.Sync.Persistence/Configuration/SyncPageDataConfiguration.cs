using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Configuration
{
    public class SyncPageDataConfiguration : IEntityTypeConfiguration<SyncPageData>
    {
        public void Configure(EntityTypeBuilder<SyncPageData> builder)
        {
            builder.
               ToTable(nameof(SyncPageData)).
               HasKey(x => x.Id);
            builder.
                Property(x => x.Page).
                IsRequired();
            builder.
                Property(x => x.TotalSynchronized).
                IsRequired();
            builder.
                Property(x => x.TotalDosNotSynchronized).
                IsRequired();
            builder.
                Property(x => x.SyncPageSuccess).
                IsRequired();
            builder.
                HasMany(x => x.SourcesWithoutSync).
                WithOne(x => x.SyncPage).
                HasForeignKey(x => x.SyncPageId);
        }
    }
}
