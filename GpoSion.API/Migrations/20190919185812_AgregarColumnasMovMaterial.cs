using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class AgregarColumnasMovMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Recibo",
                table: "MovimientosMaterial",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Viajero",
                table: "MovimientosMaterial",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recibo",
                table: "MovimientosMaterial");

            migrationBuilder.DropColumn(
                name: "Viajero",
                table: "MovimientosMaterial");
        }
    }
}
