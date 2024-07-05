using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Flexiblebookingcourtgroupid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<long>(
                name: "TotalCost",
                table: "FlexibleBooking",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<int>(
                name: "CourtGroupId",
                table: "FlexibleBooking",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "FlexibleBooking",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "FlexibleBooking",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b656a9b-ad67-4360-b771-bdf9bdfa404d", null, "Customer", "CUSTOMER" },
                    { "46e9d5f1-c765-46cf-90dc-bda97e2d608e", null, "Admin", "ADMIN" },
                    { "627fc579-ed07-4836-adb3-b490301603a4", null, "Manager", "MANAGER" },
                    { "8223b9ce-8a35-445d-a70c-a180a7a2ae8c", null, "Staff", "STAFF" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cffc3d6-7762-4a61-a1d2-434fb7716451", new DateTime(2024, 7, 5, 15, 45, 41, 988, DateTimeKind.Utc).AddTicks(939), new DateTime(2024, 7, 5, 15, 45, 41, 988, DateTimeKind.Utc).AddTicks(948), "AQAAAAIAAYagAAAAEP2t8vsjw3hq+hceMCipBKTV1nTYTlL7rJ+yJX6xsUxqljCkP1SnVmHnievv4NA0iQ==", "9d360caa-19d2-4be6-91c9-c7e07b0c85f4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b656a9b-ad67-4360-b771-bdf9bdfa404d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "46e9d5f1-c765-46cf-90dc-bda97e2d608e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "627fc579-ed07-4836-adb3-b490301603a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8223b9ce-8a35-445d-a70c-a180a7a2ae8c");

            migrationBuilder.DropColumn(
                name: "CourtGroupId",
                table: "FlexibleBooking");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "FlexibleBooking");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FlexibleBooking");

            migrationBuilder.AlterColumn<long>(
                name: "TotalCost",
                table: "FlexibleBooking",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

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
    }
}
