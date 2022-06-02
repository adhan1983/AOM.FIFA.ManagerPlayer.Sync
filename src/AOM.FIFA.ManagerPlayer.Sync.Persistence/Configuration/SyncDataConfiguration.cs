using AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.HasData(new List<SyncData>()
            {
                new SyncData { Id = 1,  Name = "League", TotalItems = 49, TotalPages = 3, TotalItemsPerPage = 20, Synchronized = false },
                new SyncData { Id = 2,  Name = "Club", TotalItems = 674, TotalPages = 34, TotalItemsPerPage = 20, Synchronized = false },
                new SyncData { Id = 3,  Name = "Player", TotalItems = 20617, TotalPages = 1031, TotalItemsPerPage = 20, Synchronized = false },
                new SyncData { Id = 4,  Name = "Nation", TotalItems = 160, TotalPages = 8, TotalItemsPerPage = 20, Synchronized = false },
            });
        }
    }
}
