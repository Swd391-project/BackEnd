using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Flexiblebookingcreateddate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "FlexibleBooking",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW() AT TIME ZONE 'UTC'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FlexibleBooking",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW() AT TIME ZONE 'UTC'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c828678-b4f3-42bf-94f3-4a100d946729", null, "Customer", "CUSTOMER" },
                    { "4c27a51c-a7af-4fa6-bf99-3e396e63e504", null, "Staff", "STAFF" },
                    { "b239fb7c-4f8d-4224-8d28-f946cfd595b5", null, "Manager", "MANAGER" },
                    { "ddbbb977-0f79-47ca-9fde-6927e10863a6", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6aa7714-c3bf-4a07-ae72-a60c2e8b7283", new DateTime(2024, 7, 5, 16, 19, 13, 935, DateTimeKind.Utc).AddTicks(9259), new DateTime(2024, 7, 5, 16, 19, 13, 935, DateTimeKind.Utc).AddTicks(9267), "AQAAAAIAAYagAAAAENX0Vgr6L6arvBKK1hAI0Ss2kA3COn0ZGqjcVFlkj0l6LQayTheyw1R6VutbUXhdfQ==", "93a38db6-03b2-4902-ba75-0285dfcdb94a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c828678-b4f3-42bf-94f3-4a100d946729");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c27a51c-a7af-4fa6-bf99-3e396e63e504");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b239fb7c-4f8d-4224-8d28-f946cfd595b5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddbbb977-0f79-47ca-9fde-6927e10863a6");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "FlexibleBooking",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW() AT TIME ZONE 'UTC'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "FlexibleBooking",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW() AT TIME ZONE 'UTC'");

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
    }
}
