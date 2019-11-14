using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class produccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Materiales_Clientes_ClienteId",
            //     table: "Materiales");

            // migrationBuilder.DropIndex(
            //     name: "IX_Materiales_ClienteId",
            //     table: "Materiales");

            // migrationBuilder.DropColumn(
            //     name: "ClienteId",
            //     table: "Materiales");

            migrationBuilder.CreateTable(
                name: "Produccion",
                columns: table => new
                {
                    ProduccionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    MoldeadoraId = table.Column<int>(nullable: true),
                    Purga = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    Colada = table.Column<decimal>(type: "decimal(18, 4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produccion", x => x.ProduccionId);
                    table.ForeignKey(
                        name: "FK_Produccion_Moldeadoras_MoldeadoraId",
                        column: x => x.MoldeadoraId,
                        principalTable: "Moldeadoras",
                        principalColumn: "MoldeadoraId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProduccionNumerosParte",
                columns: table => new
                {
                    ProduccionNumeroParteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProduccionId = table.Column<int>(nullable: false),
                    NoParte = table.Column<string>(nullable: true),
                    Piezas = table.Column<int>(nullable: false),
                    Scrap = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduccionNumerosParte", x => x.ProduccionNumeroParteId);
                    table.ForeignKey(
                        name: "FK_ProduccionNumerosParte_NumerosParte_NoParte",
                        column: x => x.NoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProduccionNumerosParte_Produccion_ProduccionId",
                        column: x => x.ProduccionId,
                        principalTable: "Produccion",
                        principalColumn: "ProduccionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produccion_MoldeadoraId",
                table: "Produccion",
                column: "MoldeadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_ProduccionNumerosParte_NoParte",
                table: "ProduccionNumerosParte",
                column: "NoParte");

            migrationBuilder.CreateIndex(
                name: "IX_ProduccionNumerosParte_ProduccionId",
                table: "ProduccionNumerosParte",
                column: "ProduccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduccionNumerosParte");

            migrationBuilder.DropTable(
                name: "Produccion");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Materiales",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_ClienteId",
                table: "Materiales",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiales_Clientes_ClienteId",
                table: "Materiales",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
