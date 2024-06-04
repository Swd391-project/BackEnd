using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BadmintonRentalSWD.Migrations
{
    /// <inheritdoc />
    public partial class seeduser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7def34bd-f46d-430e-a6e0-53560e316a3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7644cd1-712b-487f-b9cc-eb3e4892da20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca67d6db-7468-473a-917f-909c4271fe5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f922e0b7-f1a5-48d5-ace1-cbe1afeae015");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2c6b8c7a-8619-42f6-becc-b7136af92be3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08cc045c-3bf6-4e5b-b68f-ddb880dd392d", null, "Staff", "STAFF" },
                    { "8b8a51f2-8276-46a8-9611-affde9ed4591", null, "Manager", "MANAGER" },
                    { "cc00904c-9efe-4433-bfc5-1b3deb93d5d8", null, "Customer", "CUSTOMER" },
                    { "fa7fa35b-41db-4831-9831-a0d1116fc8fe", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "ModifiedBy", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cde65a51-2ce3-4226-a8da-ac7288416cff", 0, null, "95f99bab-a098-44f2-b178-6babf9b9c291", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@bbms.com", false, "System Admin", false, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Admin@123", "AQAAAAIAAYagAAAAEMw3zJOn+2aCr91ZaNQAgRM5sEddq754wPNSwIQ4FBetvUutC/VpE8km4BTmID3caA==", "1234567890", false, "Admin", "e260aadb-daba-4d72-b5be-51f32e153bd8", false, "admin@bbms.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08cc045c-3bf6-4e5b-b68f-ddb880dd392d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b8a51f2-8276-46a8-9611-affde9ed4591");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc00904c-9efe-4433-bfc5-1b3deb93d5d8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa7fa35b-41db-4831-9831-a0d1116fc8fe");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cde65a51-2ce3-4226-a8da-ac7288416cff");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7def34bd-f46d-430e-a6e0-53560e316a3a", null, "Staff", "STAFF" },
                    { "a7644cd1-712b-487f-b9cc-eb3e4892da20", null, "Manager", "MANAGER" },
                    { "ca67d6db-7468-473a-917f-909c4271fe5a", null, "Admin", "ADMIN" },
                    { "f922e0b7-f1a5-48d5-ace1-cbe1afeae015", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "ModifiedBy", "ModifiedDate", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2c6b8c7a-8619-42f6-becc-b7136af92be3", 0, null, "9e80e2a9-92ac-4a5d-ab59-43273551e1ad", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@bbms.com", false, "System Admin", false, null, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Admin@123", null, "1234567890", false, "Admin", "e16de295-d2e6-4a08-b00d-c7d85a7e14f1", false, "admin@bbms.com" });
        }
    }
}
