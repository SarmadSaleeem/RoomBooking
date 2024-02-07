using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NFS.RoomBooking.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser_AndNullableProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "db2053d7-9294-4f22-ab94-2fe2c4514261", 0, "ea30914b-bf3e-4da5-88c4-262fc995538e", "admin@gmail.com", true, "Super", null, "Admin", false, null, null, "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEKs/yEGXTt5QSpFD42iuZjy4rkXqiUtlM/5CnIIJeiYEyHuP+0Qf5LWxjwQi4j+RFg==", null, false, "4cc952af-3427-4d36-9175-f0891785e498", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d0e76862-5de0-4ac4-864c-9af18b7071ab", "db2053d7-9294-4f22-ab94-2fe2c4514261" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d0e76862-5de0-4ac4-864c-9af18b7071ab", "db2053d7-9294-4f22-ab94-2fe2c4514261" });

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "db2053d7-9294-4f22-ab94-2fe2c4514261");

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PictureUrl",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
