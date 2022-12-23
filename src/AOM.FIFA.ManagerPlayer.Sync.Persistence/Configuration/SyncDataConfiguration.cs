using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Configuration
{
    public class SyncDataConfiguration : IEntityTypeConfiguration<SyncData>
    {
        public void Configure(EntityTypeBuilder<SyncData> builder)
        {
            builder.
               ToTable(nameof(SyncData)).
               HasKey(x => x.Id);
            builder.
                Property(x => x.Name).
                HasMaxLength(60).
                IsRequired();
            builder.
                Property(x => x.TotalPages).
                IsRequired();
            builder.
                Property(x => x.TotalItems).
                IsRequired();
            builder.
                Property(x => x.TotalItemsPerPage).
                IsRequired();
            builder.
                HasMany(x => x.SyncPages).
                WithOne(x => x.Sync).
                HasForeignKey(x => x.SyncId);            
        }
    }
}
