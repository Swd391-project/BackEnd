using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Filerecordentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "FileRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Data = table.Column<byte[]>(type: "bytea", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileRecord", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5508a7cc-6070-436c-8200-e710498d96de", null, "Admin", "ADMIN" },
                    { "668262de-da9a-4793-8eff-57a014d4dd42", null, "Customer", "CUSTOMER" },
                    { "a15735d0-de63-487f-ac0a-f5b135d60424", null, "Manager", "MANAGER" },
                    { "ac6e95df-94b0-4fea-bd2a-6ee784f6baf2", null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f390d038-15ef-45ea-a14f-1c3a9f800952", new DateTime(2024, 6, 29, 15, 10, 39, 246, DateTimeKind.Utc).AddTicks(5311), new DateTime(2024, 6, 29, 15, 10, 39, 246, DateTimeKind.Utc).AddTicks(5318), "AQAAAAIAAYagAAAAEMO84GzJm11uBr9iGj4IldZt5JhDwRN+vQr4vuBKKM03wBWlz6QzXqNS8qsaUB6Czg==", "250083b0-34a9-403f-93b5-58957bfd56f8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileRecord");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5508a7cc-6070-436c-8200-e710498d96de");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "668262de-da9a-4793-8eff-57a014d4dd42");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a15735d0-de63-487f-ac0a-f5b135d60424");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ac6e95df-94b0-4fea-bd2a-6ee784f6baf2");

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
    }
}
