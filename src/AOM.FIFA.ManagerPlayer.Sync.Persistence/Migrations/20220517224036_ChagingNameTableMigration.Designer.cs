﻿// <auto-generated />
using AOM.FIFA.ManagerPlayer.Sync.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Migrations
{
    [DbContext(typeof(FIFASyncDbContext))]
    [Migration("20220517224036_ChagingNameTableMigration")]
    partial class ChagingNameTableMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data.SourceWithoutSyncData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("SourceId")
                        .HasColumnType("int");

                    b.Property<int>("SyncPageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SyncPageId");

                    b.ToTable("SourceWithoutSyncData");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data.SyncData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("Synchronized")
                        .HasColumnType("bit");

                    b.Property<int>("TotalItems")
                        .HasColumnType("int");

                    b.Property<int>("TotalItemsPerPage")
                        .HasColumnType("int");

                    b.Property<int>("TotalPages")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SyncData");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "League",
                            Synchronized = false,
                            TotalItems = 49,
                            TotalItemsPerPage = 20,
                            TotalPages = 3
                        },
                        new
                        {
                            Id = 2,
                            Name = "Club",
                            Synchronized = false,
                            TotalItems = 674,
                            TotalItemsPerPage = 20,
                            TotalPages = 34
                        },
                        new
                        {
                            Id = 3,
                            Name = "Player",
                            Synchronized = false,
                            TotalItems = 20617,
                            TotalItemsPerPage = 20,
                            TotalPages = 1031
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nation",
                            Synchronized = false,
                            TotalItems = 160,
                            TotalItemsPerPage = 20,
                            TotalPages = 8
                        });
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data.SyncPageData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Page")
                        .HasColumnType("int");

                    b.Property<int>("SyncId")
                        .HasColumnType("int");

                    b.Property<bool>("SyncPageSuccess")
                        .HasColumnType("bit");

                    b.Property<int>("TotalDosNotSynchronized")
                        .HasColumnType("int");

                    b.Property<int>("TotalSynchronized")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SyncId");

                    b.ToTable("SyncPageData");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data.SourceWithoutSyncData", b =>
                {
                    b.HasOne("AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data.SyncPageData", "SyncPage")
                        .WithMany("SourcesWithoutSync")
                        .HasForeignKey("SyncPageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SyncPage");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data.SyncPageData", b =>
                {
                    b.HasOne("AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data.SyncData", "Sync")
                        .WithMany("SyncPages")
                        .HasForeignKey("SyncId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sync");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Sync.Application.Sync.Data.SyncData", b =>
                {
                    b.Navigation("SyncPages");
                });

            modelBuilder.Entity("AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data.SyncPageData", b =>
                {
                    b.Navigation("SourcesWithoutSync");
                });
#pragma warning restore 612, 618
        }
    }
}
