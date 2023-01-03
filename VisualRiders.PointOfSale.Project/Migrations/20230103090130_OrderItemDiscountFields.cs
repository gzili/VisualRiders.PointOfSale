using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisualRiders.PointOfSale.Project.Migrations
{
    public partial class OrderItemDiscountFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountRate",
                table: "OrderItems",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountTotal",
                table: "OrderItems",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountRate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DiscountTotal",
                table: "OrderItems");
        }
    }
}
