using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class adduserimage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "769e4cbd-ef5d-427c-8cf7-a5eaee2518ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8fabbbe7-1bd4-451f-bd7d-99f8c1c35a0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d802416f-d19a-40ec-99fd-b155862fc8c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2b07be4-f13e-48f1-8e7b-6a9734737f07");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "52f387f1-e975-4f39-949c-0e14bd95143b");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10904d1d-604e-400d-adbd-56eeb09d3b27", null, "Customer", "CUSTOMER" },
                    { "4bbeda41-d849-4fba-8b5f-802c188e306b", null, "Manager", "MANAGER" },
                    { "5a3c9b6f-9954-4615-b3eb-5ebc2eda04e4", null, "Staff", "STAFF" },
                    { "921fc322-04d8-4858-847b-68588d88a05b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "FullName", "Image", "LockoutEnabled", "LockoutEnd", "ModifiedBy", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "283b1b3e-3278-43ae-b1fe-db55066d71d7", 0, null, "f4f94d34-991f-4509-9756-03c2b309ed80", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@bbms.com", false, "System Admin", null, false, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ADMIN@BBMS.COM", "Admin@123", "AQAAAAIAAYagAAAAEKIKeOsbuMNmX4BfSqjWWvq6WwZxaKe9sZ0Roskm0ylLkQa2UalHnv85B3pKfcbhVQ==", "1234567890", false, "Admin", "9e0a74d2-1b1b-4ea5-9211-68217efdd3fa", false, "admin@bbms.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10904d1d-604e-400d-adbd-56eeb09d3b27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bbeda41-d849-4fba-8b5f-802c188e306b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a3c9b6f-9954-4615-b3eb-5ebc2eda04e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "921fc322-04d8-4858-847b-68588d88a05b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "283b1b3e-3278-43ae-b1fe-db55066d71d7");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "769e4cbd-ef5d-427c-8cf7-a5eaee2518ac", null, "Staff", "STAFF" },
                    { "8fabbbe7-1bd4-451f-bd7d-99f8c1c35a0a", null, "Manager", "MANAGER" },
                    { "d802416f-d19a-40ec-99fd-b155862fc8c0", null, "Customer", "CUSTOMER" },
                    { "f2b07be4-f13e-48f1-8e7b-6a9734737f07", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "ModifiedBy", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "52f387f1-e975-4f39-949c-0e14bd95143b", 0, null, "c036d1ac-3605-4386-b96f-b7e6d8623141", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@bbms.com", false, "System Admin", false, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ADMIN@BBMS.COM", "Admin@123", "AQAAAAIAAYagAAAAEHLMPx6heWaF+kc+hVFRuU64s/kvccywfuEkQsOrFXKyrx0UAJ88vXuE9X8wOCXlOA==", "1234567890", false, "Admin", "70a830c1-45d4-4063-9477-d4b889dca57f", false, "admin@bbms.com" });
        }
    }
}
