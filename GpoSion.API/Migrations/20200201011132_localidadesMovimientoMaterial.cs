using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class localidadesMovimientoMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "MovimientosMaterial",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_LocalidadId",
                table: "MovimientosMaterial",
                column: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosMaterial_Localidades_LocalidadId",
                table: "MovimientosMaterial",
                column: "LocalidadId",
                principalTable: "Localidades",
                principalColumn: "LocalidadId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosMaterial_Localidades_LocalidadId",
                table: "MovimientosMaterial");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosMaterial_LocalidadId",
                table: "MovimientosMaterial");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "MovimientosMaterial");
        }
    }
}
