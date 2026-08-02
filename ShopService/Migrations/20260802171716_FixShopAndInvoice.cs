using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopService.Migrations
{
    /// <inheritdoc />
    public partial class FixShopAndInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhoneNumber",
                table: "Shop",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Shop",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Shop");
        }
    }
}
