using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Flexiblebookingfloattotalhours : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<float>(
                name: "TotalHours",
                table: "FlexibleBooking",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<float>(
                name: "RemainingHours",
                table: "FlexibleBooking",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bb188ac-c79c-4844-9980-c199d1ac90f5", null, "Customer", "CUSTOMER" },
                    { "70b1b18a-fc30-4342-8ee5-cc56868369eb", null, "Staff", "STAFF" },
                    { "bb9387b7-7df4-4ef6-9d76-097c76c1b2a4", null, "Admin", "ADMIN" },
                    { "e2075539-1241-4a2a-8da1-4e2d6f61c704", null, "Manager", "MANAGER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "516c404f-06d9-4bf2-b85a-c666a57c7b1d", new DateTime(2024, 7, 5, 16, 32, 2, 201, DateTimeKind.Utc).AddTicks(8551), new DateTime(2024, 7, 5, 16, 32, 2, 201, DateTimeKind.Utc).AddTicks(8567), "AQAAAAIAAYagAAAAEKb1Ni8eVnxTyqgpt+BSmCGJgOP9kxP+il0ZjUl18F20ZS9Nj8yJkhcTQ2y6nebTAg==", "2b1b2e43-09ce-4a23-b9f6-8c98a987f5a9" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3bb188ac-c79c-4844-9980-c199d1ac90f5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70b1b18a-fc30-4342-8ee5-cc56868369eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb9387b7-7df4-4ef6-9d76-097c76c1b2a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2075539-1241-4a2a-8da1-4e2d6f61c704");

            migrationBuilder.AlterColumn<int>(
                name: "TotalHours",
                table: "FlexibleBooking",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "RemainingHours",
                table: "FlexibleBooking",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

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
    }
}
