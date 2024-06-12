using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class userid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a189bec-7ad8-4ea9-863b-37f8da9dff59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e26d3dc-851e-404f-aa46-c363a7f53d32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9143699a-7ed6-4e74-a928-75275fd10ef0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0677f4a-046b-493e-82ec-c7b762d4fca0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3cb8f098-6e56-40ce-b753-64f34ce0481a", null, "Manager", "MANAGER" },
                    { "4b7112a7-169b-464d-846a-72b54fd8fdc4", null, "Admin", "ADMIN" },
                    { "87a2779f-2984-4675-b30f-6a859b6eff98", null, "Customer", "CUSTOMER" },
                    { "8f4bb645-9c6d-4400-aad3-86e947713b57", null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed9a2bd7-da96-4394-adbf-a045ae61ddc6", "AQAAAAIAAYagAAAAEKLHAEmw2GEPX7o4WhWBgyzGcTkpLSbasflLCqgUYnD+zCechmbXqK+2v8RwR9h7GQ==", "1718db23-8429-4446-ba07-a7b2da8e9102" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3cb8f098-6e56-40ce-b753-64f34ce0481a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b7112a7-169b-464d-846a-72b54fd8fdc4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "87a2779f-2984-4675-b30f-6a859b6eff98");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f4bb645-9c6d-4400-aad3-86e947713b57");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a189bec-7ad8-4ea9-863b-37f8da9dff59", null, "Staff", "STAFF" },
                    { "4e26d3dc-851e-404f-aa46-c363a7f53d32", null, "Admin", "ADMIN" },
                    { "9143699a-7ed6-4e74-a928-75275fd10ef0", null, "Customer", "CUSTOMER" },
                    { "e0677f4a-046b-493e-82ec-c7b762d4fca0", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e3ffd71-5c1f-4aa0-a979-8eceeef33d3d", "AQAAAAIAAYagAAAAEKdiFNC9oIaHmGeZiUWc5GviB9URke1dK/+UKRL8NVNIkksVbI0aoPDEICsajHTXfw==", "642d5718-114a-41b8-856b-073c9d523acb" });
        }
    }
}
