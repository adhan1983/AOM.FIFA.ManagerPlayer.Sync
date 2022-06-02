using Microsoft.EntityFrameworkCore.Migrations;

namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Migrations
{
    public partial class CreatingSyncTablesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sync",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TotalItems = table.Column<int>(type: "int", nullable: false),
                    TotalPages = table.Column<int>(type: "int", nullable: false),
                    TotalItemsPerPage = table.Column<int>(type: "int", nullable: false),
                    Synchronized = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sync", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SyncPageData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<int>(type: "int", nullable: false),
                    TotalSynchronized = table.Column<int>(type: "int", nullable: false),
                    TotalDosNotSynchronized = table.Column<int>(type: "int", nullable: false),
                    SyncPageSuccess = table.Column<bool>(type: "bit", nullable: false),
                    SyncId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncPageData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SyncPageData_Sync_SyncId",
                        column: x => x.SyncId,
                        principalTable: "Sync",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SourceWithoutSyncData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SourceId = table.Column<int>(type: "int", nullable: false),
                    SyncPageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceWithoutSyncData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SourceWithoutSyncData_SyncPageData_SyncPageId",
                        column: x => x.SyncPageId,
                        principalTable: "SyncPageData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sync",
                columns: new[] { "Id", "Name", "Synchronized", "TotalItems", "TotalItemsPerPage", "TotalPages" },
                values: new object[,]
                {
                    { 1, "League", false, 49, 20, 3 },
                    { 2, "Club", false, 674, 20, 34 },
                    { 3, "Player", false, 20617, 20, 1031 },
                    { 4, "Nation", false, 160, 20, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SourceWithoutSyncData_SyncPageId",
                table: "SourceWithoutSyncData",
                column: "SyncPageId");

            migrationBuilder.CreateIndex(
                name: "IX_SyncPageData_SyncId",
                table: "SyncPageData",
                column: "SyncId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SourceWithoutSyncData");

            migrationBuilder.DropTable(
                name: "SyncPageData");

            migrationBuilder.DropTable(
                name: "Sync");
        }
    }
}
