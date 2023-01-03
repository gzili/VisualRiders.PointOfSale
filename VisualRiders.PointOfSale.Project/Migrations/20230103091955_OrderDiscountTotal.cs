using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VisualRiders.PointOfSale.Project.Migrations
{
    public partial class OrderDiscountTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountTotal",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountTotal",
                table: "Orders");
        }
    }
}
