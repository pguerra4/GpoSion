using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class localidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localidad",
                table: "Viajeros");

            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "Viajeros",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalidadId",
                table: "DetalleRecibos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    LocalidadId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true).Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Localidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.LocalidadId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viajeros_LocalidadId",
                table: "Viajeros",
                column: "LocalidadId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRecibos_LocalidadId",
                table: "DetalleRecibos",
                column: "LocalidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleRecibos_Localidades_LocalidadId",
                table: "DetalleRecibos",
                column: "LocalidadId",
                principalTable: "Localidades",
                principalColumn: "LocalidadId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajeros_Localidades_LocalidadId",
                table: "Viajeros",
                column: "LocalidadId",
                principalTable: "Localidades",
                principalColumn: "LocalidadId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalleRecibos_Localidades_LocalidadId",
                table: "DetalleRecibos");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajeros_Localidades_LocalidadId",
                table: "Viajeros");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_Viajeros_LocalidadId",
                table: "Viajeros");

            migrationBuilder.DropIndex(
                name: "IX_DetalleRecibos_LocalidadId",
                table: "DetalleRecibos");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "Viajeros");

            migrationBuilder.DropColumn(
                name: "LocalidadId",
                table: "DetalleRecibos");

            migrationBuilder.AddColumn<string>(
                name: "Localidad",
                table: "Viajeros",
                nullable: true);
        }
    }
}
