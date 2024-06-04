using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BadmintonRentalSWD.Migrations
{
    /// <inheritdoc />
    public partial class Seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "009a0ff8-5539-415e-8b8e-b9f63df16578", null, "Staff", "STAFF" },
                    { "19158556-90dc-4f1c-aeec-82b42f518f82", null, "Customer", "CUSTOMER" },
                    { "f415c48c-55ca-4ee3-ac14-4e1e737492b1", null, "Admin", "ADMIN" },
                    { "fca6ea28-b9eb-4bb5-a4c5-527c915c02d8", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "009a0ff8-5539-415e-8b8e-b9f63df16578");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19158556-90dc-4f1c-aeec-82b42f518f82");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f415c48c-55ca-4ee3-ac14-4e1e737492b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fca6ea28-b9eb-4bb5-a4c5-527c915c02d8");

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
    }
}
