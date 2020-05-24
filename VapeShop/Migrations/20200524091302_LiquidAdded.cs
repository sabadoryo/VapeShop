using Microsoft.EntityFrameworkCore.Migrations;

namespace VapeShop.Migrations
{
    public partial class LiquidAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vapes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Liquid",
                columns: table => new
                {
                    LiquidId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liquid", x => x.LiquidId);
                });

            migrationBuilder.CreateTable(
                name: "VapeLiquid",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LiquidId = table.Column<int>(nullable: false),
                    VapeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VapeLiquid", x => x.ID);
                    table.ForeignKey(
                        name: "FK_VapeLiquid_Liquid_LiquidId",
                        column: x => x.LiquidId,
                        principalTable: "Liquid",
                        principalColumn: "LiquidId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VapeLiquid_Vapes_VapeId",
                        column: x => x.VapeId,
                        principalTable: "Vapes",
                        principalColumn: "VapeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VapeLiquid_LiquidId",
                table: "VapeLiquid",
                column: "LiquidId");

            migrationBuilder.CreateIndex(
                name: "IX_VapeLiquid_VapeId",
                table: "VapeLiquid",
                column: "VapeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VapeLiquid");

            migrationBuilder.DropTable(
                name: "Liquid");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Vapes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
