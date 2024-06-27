using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Courtname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Court",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "377e58a0-ee4d-46f3-bbc8-14c86f64cac3", null, "Staff", "STAFF" },
                    { "c3e67e3c-6686-4578-bbd4-82a35d13edce", null, "Manager", "MANAGER" },
                    { "d193a37b-1759-4209-8e1d-f499013171b9", null, "Admin", "ADMIN" },
                    { "f0b7ef71-011d-4c6f-87c8-68a05a56dba3", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "50e7f46c-a418-4f6e-bbfb-bd0acb58a73b", new DateTime(2024, 6, 27, 15, 57, 24, 691, DateTimeKind.Utc).AddTicks(4795), new DateTime(2024, 6, 27, 15, 57, 24, 691, DateTimeKind.Utc).AddTicks(4803), "AQAAAAIAAYagAAAAEJfmMm/7l3cIDPZfjWlVqypibu8br8ykSodzv33hI1rfKBew8S+ZUNpMIk6qmVxSyg==", "03c885be-01de-4900-9789-b3efb25b85ec" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "377e58a0-ee4d-46f3-bbc8-14c86f64cac3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3e67e3c-6686-4578-bbd4-82a35d13edce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d193a37b-1759-4209-8e1d-f499013171b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0b7ef71-011d-4c6f-87c8-68a05a56dba3");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Court");

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
    }
}
