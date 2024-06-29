using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Removeurlpropertyoffilerecordentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Url",
                table: "FileRecord");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47e0dda7-f213-4f47-99b3-724e3c00fe86", null, "Staff", "STAFF" },
                    { "4ec5c75a-ca4c-4806-a414-0d1ef4bad491", null, "Admin", "ADMIN" },
                    { "698c4b15-8904-4714-b694-9306ea1be70a", null, "Customer", "CUSTOMER" },
                    { "c9959b6c-c1b2-4576-b27a-8a138c776005", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "987bf569-2e5a-4a02-a3cd-e77411260987", new DateTime(2024, 6, 29, 16, 46, 47, 856, DateTimeKind.Utc).AddTicks(1381), new DateTime(2024, 6, 29, 16, 46, 47, 856, DateTimeKind.Utc).AddTicks(1391), "AQAAAAIAAYagAAAAEEg9bbH5AHeA+S5VF7BFCzzSPF9j1I6jViPdGRwB/rkFlnH4ulnsVKiR8aAa4LHXjA==", "001b382d-7348-4d69-8d82-b47c14b031c2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "47e0dda7-f213-4f47-99b3-724e3c00fe86");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4ec5c75a-ca4c-4806-a414-0d1ef4bad491");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "698c4b15-8904-4714-b694-9306ea1be70a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9959b6c-c1b2-4576-b27a-8a138c776005");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "FileRecord",
                type: "text",
                nullable: true);

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
    }
}
