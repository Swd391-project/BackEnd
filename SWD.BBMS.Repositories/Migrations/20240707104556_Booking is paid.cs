using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SWD.BBMS.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class Bookingispaid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "Booking",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IsPaid",
                table: "Booking");

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
    }
}
