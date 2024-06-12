using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class automaticallygeneratecreateddateandmodifieddate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW() AT TIME ZONE 'UTC'",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
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
                    { "4a189bec-7ad8-4ea9-863b-37f8da9dff59", null, "Staff", "STAFF" },
                    { "4e26d3dc-851e-404f-aa46-c363a7f53d32", null, "Admin", "ADMIN" },
                    { "9143699a-7ed6-4e74-a928-75275fd10ef0", null, "Customer", "CUSTOMER" },
                    { "e0677f4a-046b-493e-82ec-c7b762d4fca0", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e3ffd71-5c1f-4aa0-a979-8eceeef33d3d", "AQAAAAIAAYagAAAAEKdiFNC9oIaHmGeZiUWc5GviB9URke1dK/+UKRL8NVNIkksVbI0aoPDEICsajHTXfw==", "642d5718-114a-41b8-856b-073c9d523acb" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a189bec-7ad8-4ea9-863b-37f8da9dff59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e26d3dc-851e-404f-aa46-c363a7f53d32");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9143699a-7ed6-4e74-a928-75275fd10ef0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0677f4a-046b-493e-82ec-c7b762d4fca0");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW() AT TIME ZONE 'UTC'");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "AspNetUsers",
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
                    { "30c947cf-3e39-41c5-86cc-e78a4767ddbe", null, "Manager", "MANAGER" },
                    { "76e4f34c-c12d-43eb-9baa-aa5f8559c1ad", null, "Admin", "ADMIN" },
                    { "b70bdff5-b1a7-4530-8b03-954e5499fe03", null, "Staff", "STAFF" },
                    { "ffcd729f-e1cd-4028-8de8-4676811b731e", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3281886a-23d5-43fa-8ce9-50d7d87761e1", "AQAAAAIAAYagAAAAECbVzm4TFBQcQUtVtoYLYXqX3P51nHW43nJYdB6qkC0w3y+aGUkwS2ooltMoRUf+Vg==", "3232f52d-c3f4-47c2-a068-d806420abd8c" });
        }
    }
}
