using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWeb.Migrations
{
    public partial class ReviewedEdition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerID",
                table: "Customer");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Customer");

            migrationBuilder.RenameColumn(
                name: "PaymentMethod",
                table: "Customer",
                newName: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Customer",
                newName: "PaymentMethod");

            migrationBuilder.AddColumn<string>(
                name: "CustomerID",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Customer",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
