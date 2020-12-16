using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class columnsExistenciasMovProducto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExistenciaAlmacenFinal",
                table: "MovimientosProducto",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExistenciaAlmacenInicial",
                table: "MovimientosProducto",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExistenciaAlmacenFinal",
                table: "MovimientosProducto");

            migrationBuilder.DropColumn(
                name: "ExistenciaAlmacenInicial",
                table: "MovimientosProducto");
        }
    }
}
