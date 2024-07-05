using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Bookingtotalcost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<long>(
                name: "TotalCost",
                table: "FlexibleBooking",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AlterColumn<float>(
                name: "Rate",
                table: "CourtGroup",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "TotalCost",
                table: "Booking",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5b4193b5-4bd7-4c43-9090-0eb7c5ace529", null, "Staff", "STAFF" },
                    { "5ddc4a87-3eac-46a0-89f0-0b02c821fe22", null, "Customer", "CUSTOMER" },
                    { "7fb4e29a-1b14-4d80-99e2-e6e14ec210d8", null, "Manager", "MANAGER" },
                    { "b6bdda0d-003a-4e90-8867-99abf539216b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b0faf401-3ca8-4e09-8ab9-4a161426d0f2", new DateTime(2024, 7, 5, 13, 20, 41, 641, DateTimeKind.Utc).AddTicks(5474), new DateTime(2024, 7, 5, 13, 20, 41, 641, DateTimeKind.Utc).AddTicks(5481), "AQAAAAIAAYagAAAAEPUF8rrq7AXDH082Ft5wSKQsnMRLnPBiScDF8D8l12n6nx3iBRVcEJ/CxeA2KS05bw==", "a10a5c64-fbcc-4528-9b13-8ad6f7602efe" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5b4193b5-4bd7-4c43-9090-0eb7c5ace529");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ddc4a87-3eac-46a0-89f0-0b02c821fe22");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fb4e29a-1b14-4d80-99e2-e6e14ec210d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b6bdda0d-003a-4e90-8867-99abf539216b");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "FlexibleBooking");

            migrationBuilder.DropColumn(
                name: "TotalCost",
                table: "Booking");

            migrationBuilder.AlterColumn<float>(
                name: "Rate",
                table: "CourtGroup",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

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
    }
}
