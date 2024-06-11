using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookStoreApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeededDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "25b8e858-91e3-4921-8055-f332fd22592e", null, "User", "USER" },
                    { "4463133f-1e6c-47db-b81d-b8a1cc2b133f", null, "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "2c6233b0-748f-48bf-a0a3-32b75ad6633a", 0, "8383ed9b-5dbe-418f-9b82-11e342bd24b8", "user@bookstore.com", false, "Charles", "Bigsby", false, null, "USER@BOOKSTORE.COM", "USER@BOOKSTORE.COM", "AQAAAAIAAYagAAAAELBC9+Q148Q9V5nsGKSlckQm34VWp1+FBeIdFnRehlsOaLPHNMjt+kQ4VR1nCO/6GA==", null, false, "0b6acabe-0bf2-453a-8280-d85dfd1515dd", false, "user@bookstore.com" },
                    { "77ff77b0-e059-467f-9239-673baacfcba7", 0, "bf110a94-7b1a-4dfa-a7c6-760ae7317173", "admin@bookstore.com", false, "Allen", "Carsley", false, null, "ADMIN@BOOKSTORE.COM", "ADMIN@BOOKSTORE.COM", "AQAAAAIAAYagAAAAEIYKnDIOllbbHfOnysauCRXY2M4mzNr6aunxsQhaqhMsQNNtLDX8V751G3YTYeQlNA==", null, false, "655b8cb7-2661-46d6-9e0f-e93bd0512e5c", false, "admin@bookstore.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "25b8e858-91e3-4921-8055-f332fd22592e", "2c6233b0-748f-48bf-a0a3-32b75ad6633a" },
                    { "4463133f-1e6c-47db-b81d-b8a1cc2b133f", "77ff77b0-e059-467f-9239-673baacfcba7" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "25b8e858-91e3-4921-8055-f332fd22592e", "2c6233b0-748f-48bf-a0a3-32b75ad6633a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4463133f-1e6c-47db-b81d-b8a1cc2b133f", "77ff77b0-e059-467f-9239-673baacfcba7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25b8e858-91e3-4921-8055-f332fd22592e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4463133f-1e6c-47db-b81d-b8a1cc2b133f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6233b0-748f-48bf-a0a3-32b75ad6633a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "77ff77b0-e059-467f-9239-673baacfcba7");
        }
    }
}
