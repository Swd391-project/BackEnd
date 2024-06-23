using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Statusforcourtgroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c36a8f36-ad83-437b-8a53-242691ce8c4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb305145-20ed-4132-bc4b-94861badc5f7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbdb6d51-2d25-4bed-aef0-573b6e236936");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f647500a-7d6e-4dec-8717-de9b6f8844a5");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "CourtGroup",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Status",
                table: "CourtGroup");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c36a8f36-ad83-437b-8a53-242691ce8c4d", null, "Admin", "ADMIN" },
                    { "cb305145-20ed-4132-bc4b-94861badc5f7", null, "Staff", "STAFF" },
                    { "dbdb6d51-2d25-4bed-aef0-573b6e236936", null, "Customer", "CUSTOMER" },
                    { "f647500a-7d6e-4dec-8717-de9b6f8844a5", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2a77681f-4ee6-4b57-9085-0454fdd75315", new DateTime(2024, 6, 19, 19, 37, 49, 717, DateTimeKind.Utc).AddTicks(219), new DateTime(2024, 6, 19, 19, 37, 49, 717, DateTimeKind.Utc).AddTicks(232), "AQAAAAIAAYagAAAAEEKZyIYK9hfdbiCxgTLp54TWgPX8DLJf9iWBTZCeDyHuFnBWUC5whQLsSNJ5Wau5Ww==", "8df2c98c-b66a-4ea5-a51e-b101ad784bcd" });
        }
    }
}
