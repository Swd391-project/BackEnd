using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BadmintonRentalSWD.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "7def34bd-f46d-430e-a6e0-53560e316a3a", null, "Staff", "STAFF" },
                    { "a7644cd1-712b-487f-b9cc-eb3e4892da20", null, "Manager", "MANAGER" },
                    { "ca67d6db-7468-473a-917f-909c4271fe5a", null, "Admin", "ADMIN" },
                    { "f922e0b7-f1a5-48d5-ace1-cbe1afeae015", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "ModifiedBy", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2c6b8c7a-8619-42f6-becc-b7136af92be3", 0, null, "9e80e2a9-92ac-4a5d-ab59-43273551e1ad", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@bbms.com", false, "System Admin", false, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Admin@123", null, "1234567890", false, "Admin", "e16de295-d2e6-4a08-b00d-c7d85a7e14f1", false, "admin@bbms.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7def34bd-f46d-430e-a6e0-53560e316a3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7644cd1-712b-487f-b9cc-eb3e4892da20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca67d6db-7468-473a-917f-909c4271fe5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f922e0b7-f1a5-48d5-ace1-cbe1afeae015");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6b8c7a-8619-42f6-becc-b7136af92be3");

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
    }
}
