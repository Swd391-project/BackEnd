using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Deletedstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0d562a3b-a1da-4852-bcc1-e7b8760c3a4e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d81a12e-ce49-43b6-af71-dc20d4fe544e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d22766b-a457-412c-b64a-a9b869ccdc96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4338885-0c8e-4095-8ee4-28cfe681a1f3");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d562a3b-a1da-4852-bcc1-e7b8760c3a4e", null, "Manager", "MANAGER" },
                    { "3d81a12e-ce49-43b6-af71-dc20d4fe544e", null, "Admin", "ADMIN" },
                    { "8d22766b-a457-412c-b64a-a9b869ccdc96", null, "Customer", "CUSTOMER" },
                    { "b4338885-0c8e-4095-8ee4-28cfe681a1f3", null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60c60101-1b76-456b-a593-d8fcb810e596", new DateTime(2024, 6, 21, 19, 40, 0, 978, DateTimeKind.Utc).AddTicks(9081), new DateTime(2024, 6, 21, 19, 40, 0, 978, DateTimeKind.Utc).AddTicks(9089), "AQAAAAIAAYagAAAAEPMCQFK2DIoG5vjno/XqBcCJrP1Hn7fDEqv6YQJC2aA0bB8yT1zXDkgqp78mvB24sQ==", "cf51dd25-4d6c-4d00-8780-12a6f596131a" });
        }
    }
}
