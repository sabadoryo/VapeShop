using Microsoft.EntityFrameworkCore.Migrations;

namespace VapeShop.Migrations
{
    public partial class LiquidEdited : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageThumbnailUrl",
                table: "Liquid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Liquid",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Liquid",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageThumbnailUrl",
                table: "Liquid");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Liquid");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Liquid");
        }
    }
}
