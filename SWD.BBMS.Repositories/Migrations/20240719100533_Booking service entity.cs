using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Bookingserviceentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e0a9535-a09d-451a-a36d-e94b4ded3a2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a426f10-d49c-4f11-8ff8-477e4dd2e3cc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c435fe36-c6f4-4f88-b6cc-b2f5740dc208");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dec5508c-671a-446c-994c-78984030114f");

            migrationBuilder.AddColumn<double>(
                name: "ServicesPrice",
                table: "Booking",
                type: "double precision",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BookingService",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "integer", nullable: false),
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingService", x => new { x.BookingId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_BookingService_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3d3a7e9d-5955-45a8-adb7-d0728a680b0d", null, "Customer", "CUSTOMER" },
                    { "a7a57f94-add3-4712-af72-4e5ec5f81e47", null, "Admin", "ADMIN" },
                    { "cbf9650c-bc9a-41a4-8548-cbffc221f22d", null, "Manager", "MANAGER" },
                    { "d2170197-6e4c-4951-95a7-6c9673a9679f", null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04cc08cc-2fb7-49b3-a5b0-1b6d952fb32a", new DateTime(2024, 7, 19, 10, 5, 33, 197, DateTimeKind.Utc).AddTicks(7401), new DateTime(2024, 7, 19, 10, 5, 33, 197, DateTimeKind.Utc).AddTicks(7408), "AQAAAAIAAYagAAAAECL1NWFNPHM+ytDbp/zyelm4g9qjBMh/bOdPOmGcYo4IxCY5+ilckc+DnMtFnzoaOg==", "4127d60c-9d0a-4316-b087-837a88a5811e" });

            migrationBuilder.CreateIndex(
                name: "IX_BookingService_ServiceId",
                table: "BookingService",
                column: "ServiceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingService");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3d3a7e9d-5955-45a8-adb7-d0728a680b0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7a57f94-add3-4712-af72-4e5ec5f81e47");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cbf9650c-bc9a-41a4-8548-cbffc221f22d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d2170197-6e4c-4951-95a7-6c9673a9679f");

            migrationBuilder.DropColumn(
                name: "ServicesPrice",
                table: "Booking");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e0a9535-a09d-451a-a36d-e94b4ded3a2f", null, "Customer", "CUSTOMER" },
                    { "7a426f10-d49c-4f11-8ff8-477e4dd2e3cc", null, "Staff", "STAFF" },
                    { "c435fe36-c6f4-4f88-b6cc-b2f5740dc208", null, "Manager", "MANAGER" },
                    { "dec5508c-671a-446c-994c-78984030114f", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "efb15963-0b54-4e14-ada9-f74ab3420545", new DateTime(2024, 7, 14, 15, 3, 49, 940, DateTimeKind.Utc).AddTicks(4694), new DateTime(2024, 7, 14, 15, 3, 49, 940, DateTimeKind.Utc).AddTicks(4701), "AQAAAAIAAYagAAAAEDtzW1eFDWiQtjlY2gze8SgKKRvDED6MC0bMdiCF6P9D0tSIvDTQLIrRCk3duzgwQQ==", "9dff4330-3d77-4127-bf94-4bc91c1002df" });
        }
    }
}
