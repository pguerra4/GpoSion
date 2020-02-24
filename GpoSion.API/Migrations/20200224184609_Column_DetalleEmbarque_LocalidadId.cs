using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class Column_DetalleEmbarque_LocalidadId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "DetallesEmbarque",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEmbarque_LocalidadId",
                table: "DetallesEmbarque",
                column: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEmbarque_Localidades_LocalidadId",
                table: "DetallesEmbarque",
                column: "LocalidadId",
                principalTable: "Localidades",
                principalColumn: "LocalidadId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEmbarque_Localidades_LocalidadId",
                table: "DetallesEmbarque");

            migrationBuilder.DropIndex(
                name: "IX_DetallesEmbarque_LocalidadId",
                table: "DetallesEmbarque");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "DetallesEmbarque");
        }
    }
}
