using Microsoft.EntityFrameworkCore.Migrations;

namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Migrations
{
    public partial class ChagingNameTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SyncPageData_Sync_SyncId",
                table: "SyncPageData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sync",
                table: "Sync");

            migrationBuilder.RenameTable(
                name: "Sync",
                newName: "SyncData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SyncData",
                table: "SyncData",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SyncPageData_SyncData_SyncId",
                table: "SyncPageData",
                column: "SyncId",
                principalTable: "SyncData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SyncPageData_SyncData_SyncId",
                table: "SyncPageData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SyncData",
                table: "SyncData");

            migrationBuilder.RenameTable(
                name: "SyncData",
                newName: "Sync");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sync",
                table: "Sync",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SyncPageData_Sync_SyncId",
                table: "SyncPageData",
                column: "SyncId",
                principalTable: "Sync",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
