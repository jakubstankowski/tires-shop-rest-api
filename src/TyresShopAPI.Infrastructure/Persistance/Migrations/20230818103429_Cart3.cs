using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyresShopAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cart3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProudctId",
                table: "CartItem",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProudctId",
                table: "CartItem");
        }
    }
}
