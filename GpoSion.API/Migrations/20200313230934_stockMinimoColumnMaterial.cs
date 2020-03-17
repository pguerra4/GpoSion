using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class stockMinimoColumnMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockMinimo",
                table: "NumerosParte");

            migrationBuilder.AddColumn<int>(
                name: "StockMinimo",
                table: "Materiales",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StockMinimo",
                table: "Materiales");

            migrationBuilder.AddColumn<int>(
                name: "StockMinimo",
                table: "NumerosParte",
                nullable: false,
                defaultValue: 0);
        }
    }
}
