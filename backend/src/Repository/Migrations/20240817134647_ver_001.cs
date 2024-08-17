using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class ver_001 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kilometers = table.Column<int>(type: "int", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: true),
                    ServiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasWarranty = table.Column<bool>(type: "bit", nullable: true),
                    ServiceCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceEntries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "Admin Kaçmaz", new byte[] { 178, 64, 149, 107, 210, 217, 147, 202, 48, 86, 83, 148, 3, 56, 17, 236, 30, 136, 200, 29, 149, 127, 35, 116, 244, 27, 21, 36, 113, 187, 228, 91, 201, 184, 242, 85, 208, 175, 51, 36, 227, 49, 158, 137, 172, 79, 216, 214, 67, 152, 11, 176, 167, 252, 152, 250, 111, 226, 132, 223, 66, 106, 16, 211 }, new byte[] { 14, 205, 67, 194, 45, 90, 239, 197, 197, 20, 108, 218, 234, 167, 174, 103, 112, 97, 181, 4, 148, 175, 35, 71, 159, 79, 181, 204, 15, 225, 73, 38, 175, 49, 13, 254, 102, 181, 183, 198, 165, 168, 68, 51, 178, 230, 103, 96, 140, 97, 113, 96, 176, 103, 60, 248, 203, 87, 234, 106, 121, 255, 88, 118, 49, 23, 123, 15, 155, 191, 240, 73, 247, 210, 113, 53, 109, 39, 233, 237, 131, 72, 189, 126, 253, 38, 125, 205, 154, 72, 104, 127, 194, 206, 79, 79, 226, 122, 106, 248, 5, 160, 242, 218, 54, 49, 109, 128, 136, 132, 68, 129, 153, 143, 202, 61, 128, 205, 30, 221, 46, 48, 99, 28, 128, 104, 182, 249 }, true, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceEntry_LicensePlate",
                table: "ServiceEntries",
                column: "LicensePlate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceEntries");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
