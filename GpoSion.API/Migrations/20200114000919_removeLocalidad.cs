using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class removeLocalidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_DetalleRecibos_Localidades_LocalidadId",
            //     table: "DetalleRecibos");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_Viajeros_Localidades_LocalidadId",
            //     table: "Viajeros");

            // migrationBuilder.DropTable(
            //     name: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_Viajeros_LocalidadId",
                table: "Viajeros");

            migrationBuilder.DropIndex(
                name: "IX_DetalleRecibos_LocalidadId",
                table: "DetalleRecibos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            // migrationBuilder.CreateTable(
            //     name: "Localidades",
            //     columns: table => new
            //     {
            //         LocalidadId = table.Column<int>(nullable: false),
            //         Descripcion = table.Column<string>(nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Localidades", x => x.LocalidadId);
            //     });

            migrationBuilder.CreateIndex(
                name: "IX_Viajeros_LocalidadId",
                table: "Viajeros",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRecibos_LocalidadId",
                table: "DetalleRecibos",
                column: "LocalidadId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_DetalleRecibos_Localidades_LocalidadId",
            //     table: "DetalleRecibos",
            //     column: "LocalidadId",
            //     principalTable: "Localidades",
            //     principalColumn: "LocalidadId",
            //     onDelete: ReferentialAction.Restrict);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Viajeros_Localidades_LocalidadId",
            //     table: "Viajeros",
            //     column: "LocalidadId",
            //     principalTable: "Localidades",
            //     principalColumn: "LocalidadId",
            //     onDelete: ReferentialAction.Restrict);
        }
    }
}
