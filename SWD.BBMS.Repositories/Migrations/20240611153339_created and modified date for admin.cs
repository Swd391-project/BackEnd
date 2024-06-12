using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class createdandmodifieddateforadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "0ab2180a-0360-4aeb-94fd-c2e649d6ce5f", null, "Admin", "ADMIN" },
                    { "27fd46a7-da07-489d-8af5-308a954c20fb", null, "Customer", "CUSTOMER" },
                    { "aee6eca7-9f6b-4a93-ada1-26f6bee2a93a", null, "Staff", "STAFF" },
                    { "e8ee408e-6c51-4a96-9c17-cb7c8d88b221", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6487dc1d-4aeb-4ad2-b01e-3a79e55e7039", new DateTime(2024, 6, 11, 15, 33, 39, 415, DateTimeKind.Utc).AddTicks(4998), new DateTime(2024, 6, 11, 15, 33, 39, 415, DateTimeKind.Utc).AddTicks(5003), "AQAAAAIAAYagAAAAEGiYTzYm1IkH175KWlIho8aeKyeqbcqqgA53nV0TatL53bTkxtMpVqDEyY4T4evN8Q==", "aca309df-aa22-4c6b-8cc3-33bfdc663220" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ab2180a-0360-4aeb-94fd-c2e649d6ce5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "27fd46a7-da07-489d-8af5-308a954c20fb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aee6eca7-9f6b-4a93-ada1-26f6bee2a93a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8ee408e-6c51-4a96-9c17-cb7c8d88b221");

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
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed9a2bd7-da96-4394-adbf-a045ae61ddc6", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AQAAAAIAAYagAAAAEKLHAEmw2GEPX7o4WhWBgyzGcTkpLSbasflLCqgUYnD+zCechmbXqK+2v8RwR9h7GQ==", "1718db23-8429-4446-ba07-a7b2da8e9102" });
        }
    }
}
