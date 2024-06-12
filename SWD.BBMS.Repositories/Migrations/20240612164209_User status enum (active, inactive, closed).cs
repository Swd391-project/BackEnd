using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Userstatusenumactiveinactiveclosed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "63e6bd94-70e6-49c9-8ce8-1aa6e8793f3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c11d85f-a505-4c59-843b-5b2cd58668a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d93c446e-1589-4485-9787-b581b9142046");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5a560e5-6b44-41ab-a54e-5a3b9ec1fd21");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "62b193da-0ba5-4008-bf8e-3ec7a0da9501", null, "Manager", "MANAGER" },
                    { "6ee4a9c7-a09e-41a1-b922-2a534d952958", null, "Customer", "CUSTOMER" },
                    { "e8254962-1620-4277-9890-4a0f637f0100", null, "Admin", "ADMIN" },
                    { "eae05aeb-8e85-47a3-b5d2-2a4069f31773", null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp", "Status" },
                values: new object[] { "7a59d57c-65af-4cce-9580-2a1162149c68", new DateTime(2024, 6, 12, 16, 42, 9, 576, DateTimeKind.Utc).AddTicks(1245), new DateTime(2024, 6, 12, 16, 42, 9, 576, DateTimeKind.Utc).AddTicks(1252), "AQAAAAIAAYagAAAAEJmq2yr1VnAbFx54ItnAX50jM0BDBqAVgv0ZvMMfiv2Hn5/Vjv+LEjVxyAOgLbUI3w==", "0cd7b574-1ca7-4ab5-afe3-ee9fc77d546f", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "62b193da-0ba5-4008-bf8e-3ec7a0da9501");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ee4a9c7-a09e-41a1-b922-2a534d952958");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8254962-1620-4277-9890-4a0f637f0100");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eae05aeb-8e85-47a3-b5d2-2a4069f31773");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "63e6bd94-70e6-49c9-8ce8-1aa6e8793f3d", null, "Manager", "MANAGER" },
                    { "6c11d85f-a505-4c59-843b-5b2cd58668a8", null, "Customer", "CUSTOMER" },
                    { "d93c446e-1589-4485-9787-b581b9142046", null, "Admin", "ADMIN" },
                    { "e5a560e5-6b44-41ab-a54e-5a3b9ec1fd21", null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "647a251a-4f76-4d02-96d4-1f041fca5b50", new DateTime(2024, 6, 11, 18, 0, 55, 648, DateTimeKind.Utc).AddTicks(2173), new DateTime(2024, 6, 11, 18, 0, 55, 648, DateTimeKind.Utc).AddTicks(2181), "AQAAAAIAAYagAAAAEPo1JPOZE4vX6Bv1i9wVD6qbZCXRHKcnWC9VfrmAwFvg0BDfOz7Qv86U8fq6qJmnAw==", "739854f5-e984-4570-a6be-3f34c09b0455" });
        }
    }
}
