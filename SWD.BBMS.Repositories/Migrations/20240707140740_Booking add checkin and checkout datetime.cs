using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Bookingaddcheckinandcheckoutdatetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12ecbd0e-5a64-4707-9281-736db59bd727");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "483bf97f-22a6-453b-87c6-2e8fe0214484");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a40380a9-0f7a-403e-a911-bdfdc8c2b5bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d267acb0-6718-4366-a1a0-3bd1d84322ee");

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckinTime",
                table: "Booking",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckoutTime",
                table: "Booking",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "216da692-807f-4413-8e4e-6be7c585c67e", null, "Staff", "STAFF" },
                    { "7d3d5c82-cc6a-4bf0-bf3b-5f0b6bbb9541", null, "Manager", "MANAGER" },
                    { "c701a018-64fe-4087-99b4-1e52e72e76bd", null, "Customer", "CUSTOMER" },
                    { "f0015d89-6728-4830-b480-22d6a976a68e", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e4f501b-11a0-482a-9207-f24427bcb2b2", new DateTime(2024, 7, 7, 14, 7, 40, 517, DateTimeKind.Utc).AddTicks(8742), new DateTime(2024, 7, 7, 14, 7, 40, 517, DateTimeKind.Utc).AddTicks(8754), "AQAAAAIAAYagAAAAEBxJRrk0pYa+e04+vVaXqaSS/NXat5R4JSVtG1/MjRlSZcO1jYAqX+I12oECR+NOIg==", "2c78046c-8a5a-4042-82a2-acbf2bff51f8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "216da692-807f-4413-8e4e-6be7c585c67e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d3d5c82-cc6a-4bf0-bf3b-5f0b6bbb9541");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c701a018-64fe-4087-99b4-1e52e72e76bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f0015d89-6728-4830-b480-22d6a976a68e");

            migrationBuilder.DropColumn(
                name: "CheckinTime",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CheckoutTime",
                table: "Booking");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12ecbd0e-5a64-4707-9281-736db59bd727", null, "Admin", "ADMIN" },
                    { "483bf97f-22a6-453b-87c6-2e8fe0214484", null, "Customer", "CUSTOMER" },
                    { "a40380a9-0f7a-403e-a911-bdfdc8c2b5bd", null, "Manager", "MANAGER" },
                    { "d267acb0-6718-4366-a1a0-3bd1d84322ee", null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6426982-a86b-4416-ba99-739e95a7d1aa", new DateTime(2024, 7, 7, 14, 6, 30, 483, DateTimeKind.Utc).AddTicks(3120), new DateTime(2024, 7, 7, 14, 6, 30, 483, DateTimeKind.Utc).AddTicks(3127), "AQAAAAIAAYagAAAAEMJApofGa0EB15CIKhHvyhol+O2aghqPvfaHXCoEyRGpEXb/+YN5/pW1jLLT5BVLlw==", "5c974e87-f198-45c7-af80-97d22bc34d3b" });
        }
    }
}
