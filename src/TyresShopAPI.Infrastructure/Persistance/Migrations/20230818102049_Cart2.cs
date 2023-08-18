using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyresShopAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cart2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserMail",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserMail",
                table: "Cart");
        }
    }
}
