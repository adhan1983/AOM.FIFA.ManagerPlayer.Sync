using Microsoft.EntityFrameworkCore.Migrations;

namespace AOM.FIFA.ManagerPlayer.Sync.Persistence.Migrations
{
    public partial class RemoveInsertDataFromSync : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SyncData",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SyncData",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SyncData",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SyncData",
                keyColumn: "Id",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SyncData",
                columns: new[] { "Id", "Name", "Synchronized", "TotalItems", "TotalItemsPerPage", "TotalPages" },
                values: new object[,]
                {
                    { 1, "League", false, 49, 20, 3 },
                    { 2, "Club", false, 674, 20, 34 },
                    { 3, "Player", false, 20617, 20, 1031 },
                    { 4, "Nation", false, 160, 20, 8 }
                });
        }
    }
}
