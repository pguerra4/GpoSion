using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class columnsExistenciasMovMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ExistenciaFinal",
                table: "MovimientosMaterial",
                type: "decimal(18, 3)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExistenciaInicial",
                table: "MovimientosMaterial",
                type: "decimal(18, 3)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExistenciaFinal",
                table: "MovimientosMaterial");

            migrationBuilder.DropColumn(
                name: "ExistenciaInicial",
                table: "MovimientosMaterial");
        }
    }
}
