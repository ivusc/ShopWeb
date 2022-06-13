using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWeb.Migrations
{
    public partial class ThirdEdition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "Cart");
        }
    }
}
