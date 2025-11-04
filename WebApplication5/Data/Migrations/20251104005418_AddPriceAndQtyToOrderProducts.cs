using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication5.Data.Migrations
{
    public partial class AddPriceAndQtyToOrderProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "orderProducts",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Qty",
                table: "orderProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "orderProducts");

            migrationBuilder.DropColumn(
                name: "Qty",
                table: "orderProducts");
        }
    }
}
