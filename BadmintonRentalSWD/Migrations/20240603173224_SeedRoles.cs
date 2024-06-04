using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BadmintonRentalSWD.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "21947d63-1c9c-4634-b5c1-71446ed60e2d", null, "Staff", "STAFF" },
                    { "5ddb7caf-454d-418d-8d43-a993a56a01ce", null, "Customer", "CUSTOMER" },
                    { "b41117ef-1799-4cf4-a548-4b4922d45e73", null, "Manager", "MANAGER" },
                    { "d0f64cf7-9465-44f7-81d8-4eb79328d2f7", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "21947d63-1c9c-4634-b5c1-71446ed60e2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ddb7caf-454d-418d-8d43-a993a56a01ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b41117ef-1799-4cf4-a548-4b4922d45e73");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0f64cf7-9465-44f7-81d8-4eb79328d2f7");
        }
    }
}
