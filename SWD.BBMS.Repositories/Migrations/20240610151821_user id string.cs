using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class useridstring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_AspNetUsers_UserId",
                table: "Feedback");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10904d1d-604e-400d-adbd-56eeb09d3b27");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bbeda41-d849-4fba-8b5f-802c188e306b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a3c9b6f-9954-4615-b3eb-5ebc2eda04e4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "921fc322-04d8-4858-847b-68588d88a05b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "283b1b3e-3278-43ae-b1fe-db55066d71d7");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Feedback",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

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
                    { "30c947cf-3e39-41c5-86cc-e78a4767ddbe", null, "Manager", "MANAGER" },
                    { "76e4f34c-c12d-43eb-9baa-aa5f8559c1ad", null, "Admin", "ADMIN" },
                    { "b70bdff5-b1a7-4530-8b03-954e5499fe03", null, "Staff", "STAFF" },
                    { "ffcd729f-e1cd-4028-8de8-4676811b731e", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "FullName", "Image", "LockoutEnabled", "LockoutEnd", "ModifiedBy", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, null, "3281886a-23d5-43fa-8ce9-50d7d87761e1", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@bbms.com", false, "System Admin", null, false, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ADMIN@BBMS.COM", "Admin@123", "AQAAAAIAAYagAAAAECbVzm4TFBQcQUtVtoYLYXqX3P51nHW43nJYdB6qkC0w3y+aGUkwS2ooltMoRUf+Vg==", "1234567890", false, "Admin", "3232f52d-c3f4-47c2-a068-d806420abd8c", false, "admin@bbms.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_AspNetUsers_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedback_AspNetUsers_UserId",
                table: "Feedback");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30c947cf-3e39-41c5-86cc-e78a4767ddbe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76e4f34c-c12d-43eb-9baa-aa5f8559c1ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b70bdff5-b1a7-4530-8b03-954e5499fe03");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffcd729f-e1cd-4028-8de8-4676811b731e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DropColumn(
                name: "CheckinTime",
                table: "Booking");

            migrationBuilder.DropColumn(
                name: "CheckoutTime",
                table: "Booking");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Feedback",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10904d1d-604e-400d-adbd-56eeb09d3b27", null, "Customer", "CUSTOMER" },
                    { "4bbeda41-d849-4fba-8b5f-802c188e306b", null, "Manager", "MANAGER" },
                    { "5a3c9b6f-9954-4615-b3eb-5ebc2eda04e4", null, "Staff", "STAFF" },
                    { "921fc322-04d8-4858-847b-68588d88a05b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "FullName", "Image", "LockoutEnabled", "LockoutEnd", "ModifiedBy", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "283b1b3e-3278-43ae-b1fe-db55066d71d7", 0, null, "f4f94d34-991f-4509-9756-03c2b309ed80", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@bbms.com", false, "System Admin", null, false, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "ADMIN@BBMS.COM", "Admin@123", "AQAAAAIAAYagAAAAEKIKeOsbuMNmX4BfSqjWWvq6WwZxaKe9sZ0Roskm0ylLkQa2UalHnv85B3pKfcbhVQ==", "1234567890", false, "Admin", "9e0a74d2-1b1b-4ea5-9211-68217efdd3fa", false, "admin@bbms.com" });

            migrationBuilder.AddForeignKey(
                name: "FK_Feedback_AspNetUsers_UserId",
                table: "Feedback",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
