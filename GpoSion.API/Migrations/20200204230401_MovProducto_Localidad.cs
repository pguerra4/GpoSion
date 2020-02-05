using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class MovProducto_Localidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "MovimientosProducto");

            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "MovimientosProducto",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosProducto_LocalidadId",
                table: "MovimientosProducto",
                column: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosProducto_Localidades_LocalidadId",
                table: "MovimientosProducto",
                column: "LocalidadId",
                principalTable: "Localidades",
                principalColumn: "LocalidadId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosProducto_Localidades_LocalidadId",
                table: "MovimientosProducto");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosProducto_LocalidadId",
                table: "MovimientosProducto");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "MovimientosProducto");

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "MovimientosProducto",
                nullable: true);
        }
    }
}
