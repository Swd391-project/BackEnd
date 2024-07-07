using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Paymentnewproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Payment",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Payment",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Success",
                table: "Payment",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TransactionId",
                table: "Payment",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a8095b48-9ab7-4406-afab-c1643ed04c01", null, "Manager", "MANAGER" },
                    { "bc5f7e82-5b31-4907-a378-94b7bd85d771", null, "Admin", "ADMIN" },
                    { "ead4060b-4293-4ec7-ba08-d64a8b5a6c5a", null, "Staff", "STAFF" },
                    { "f6b23679-695d-4a3a-86dc-1af89a0d4123", null, "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "ModifiedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55557fb9-6108-4b92-bf5d-08255b1138b1", new DateTime(2024, 7, 6, 17, 19, 49, 526, DateTimeKind.Utc).AddTicks(683), new DateTime(2024, 7, 6, 17, 19, 49, 526, DateTimeKind.Utc).AddTicks(730), "AQAAAAIAAYagAAAAEElwUrBeaiepBJwwFBDbUx5uftvkYIvumqM4WUqXHTyyojRP8qsmOFmT6oir8GZQRg==", "b94f4fe0-0b3d-4807-94b8-982875568091" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a8095b48-9ab7-4406-afab-c1643ed04c01");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc5f7e82-5b31-4907-a378-94b7bd85d771");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ead4060b-4293-4ec7-ba08-d64a8b5a6c5a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6b23679-695d-4a3a-86dc-1af89a0d4123");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Success",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Payment");

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
    }
}
