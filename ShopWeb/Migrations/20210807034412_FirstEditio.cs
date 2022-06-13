using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWeb.Migrations
{
    public partial class FirstEditio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityBought = table.Column<int>(type: "int", nullable: false),
                    Paid = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeBought = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Photopath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
