using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NFS.RoomBooking.API.Migrations
{
    /// <inheritdoc />
    public partial class RolesSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f55d065-c3cf-46d6-a705-6bb50a36d8fc", null, "User", "User" },
                    { "99992fd3-b266-450a-ac72-a0b581c13a1e", null, "Reception", "Reception" },
                    { "d0e76862-5de0-4ac4-864c-9af18b7071ab", null, "Administrator", "Administrator" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2f55d065-c3cf-46d6-a705-6bb50a36d8fc");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "99992fd3-b266-450a-ac72-a0b581c13a1e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d0e76862-5de0-4ac4-864c-9af18b7071ab");
        }
    }
}
