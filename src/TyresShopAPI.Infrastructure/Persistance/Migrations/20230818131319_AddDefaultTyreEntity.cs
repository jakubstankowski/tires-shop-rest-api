using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TyresShopAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultTyreEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tyres",
                columns: new[] { "Id", "IsAvailable", "IsDeleted", "Model", "Price", "ProducerId", "ProductionYear", "SizeDiameter", "SizeProfile", "SizeWidth", "TyresType" },
                values: new object[,]
                {
                    { 1, true, false, "P2", 125.50m, 1, 2020, 225, 16, 50, 0 },
                    { 2, true, false, "P3", 125.50m, 1, 2021, 225, 16, 50, 0 },
                    { 3, true, false, "P4", 125.50m, 1, 2022, 225, 16, 50, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tyres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tyres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tyres",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
