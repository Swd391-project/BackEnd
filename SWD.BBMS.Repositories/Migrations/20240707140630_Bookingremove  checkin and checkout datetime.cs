using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Bookingremovecheckinandcheckoutdatetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "07936174-7576-465f-a2d0-771d74340047");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e3f98ba-42c1-4ea4-929f-2bb175401fcf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24e79b06-66dc-4948-b226-61a006cc6ef8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c478314-f0fe-479d-af48-827459059903");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<TimeOnly>(
                name: "CheckinTime",
                table: "Booking",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.AddColumn<TimeOnly>(
                name: "CheckoutTime",
                table: "Booking",
                type: "time without time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "07936174-7576-465f-a2d0-771d74340047", null, "Staff", "STAFF" },
                    { "1e3f98ba-42c1-4ea4-929f-2bb175401fcf", null, "Admin", "ADMIN" },
                    { "24e79b06-66dc-4948-b226-61a006cc6ef8", null, "Manager", "MANAGER" },
                    { "8c478314-f0fe-479d-af48-827459059903", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6a76986a-6252-4e79-aac7-5fb11b419e24", new DateTime(2024, 7, 7, 10, 45, 56, 771, DateTimeKind.Utc).AddTicks(2687), new DateTime(2024, 7, 7, 10, 45, 56, 771, DateTimeKind.Utc).AddTicks(2691), "AQAAAAIAAYagAAAAEBErO0aWIOotTlTdJ8hed3vFNZnslN+og3BWvTrsykJYKg1vpmnHYzBHrxaFsE2PPg==", "e1420147-e8c1-474c-96a1-44ce89fcdc88" });
        }
    }
}
