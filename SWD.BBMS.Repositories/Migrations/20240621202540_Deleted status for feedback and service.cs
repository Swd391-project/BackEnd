using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Deletedstatusforfeedbackandservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30c74b3a-1a57-4582-8596-c9db5e19ce80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "954a464a-27b1-4081-81b6-7322fe26434c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6d702f1-3165-43d8-bb0a-6bc41d7d4c6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6fcbb50-8d8b-4aa7-a49e-59ca8a71abdc");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Service",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Feedback",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "182787fa-31d6-4cbd-b00d-24549da5e155", null, "Manager", "MANAGER" },
                    { "61a774d5-89aa-4ffc-96f9-67d1ae238a94", null, "Staff", "STAFF" },
                    { "856b0a1f-f905-4b72-bb5c-bbbb3f3131ff", null, "Admin", "ADMIN" },
                    { "d25752eb-8108-4cd1-a18c-3c1c387f41ab", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4c09d51-dd3e-4b32-b5f4-96fb16c6ff37", new DateTime(2024, 6, 21, 20, 25, 39, 921, DateTimeKind.Utc).AddTicks(9457), new DateTime(2024, 6, 21, 20, 25, 39, 921, DateTimeKind.Utc).AddTicks(9463), "AQAAAAIAAYagAAAAEH9tQA0ebLONqBGBE4TbCgNT8Lo05qSJZ8qagHeohGTLvN8WD/jhg1KYdqxpu4awGg==", "f0b9a4be-56ae-421e-ba05-1b790c00d2b9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "182787fa-31d6-4cbd-b00d-24549da5e155");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61a774d5-89aa-4ffc-96f9-67d1ae238a94");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "856b0a1f-f905-4b72-bb5c-bbbb3f3131ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d25752eb-8108-4cd1-a18c-3c1c387f41ab");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Feedback");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30c74b3a-1a57-4582-8596-c9db5e19ce80", null, "Customer", "CUSTOMER" },
                    { "954a464a-27b1-4081-81b6-7322fe26434c", null, "Staff", "STAFF" },
                    { "d6d702f1-3165-43d8-bb0a-6bc41d7d4c6d", null, "Admin", "ADMIN" },
                    { "f6fcbb50-8d8b-4aa7-a49e-59ca8a71abdc", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af13cd9b-8c1d-4267-8a96-fa505c4150cf", new DateTime(2024, 6, 21, 19, 59, 17, 277, DateTimeKind.Utc).AddTicks(3654), new DateTime(2024, 6, 21, 19, 59, 17, 277, DateTimeKind.Utc).AddTicks(3661), "AQAAAAIAAYagAAAAEIP6B5Pc3vhE74RSSI20TxygO6XP0skpUp/gQyvuwWPdNFDkbiSfDF7x3dx0DMpBvw==", "f366f4a5-e5c7-4d9f-829b-003c4d2f387a" });
        }
    }
}
