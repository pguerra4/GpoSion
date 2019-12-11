using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class dropMovimientosMoldeadora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimientosMoldeadora");

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Moldeadoras",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "Moldeadoras");

            migrationBuilder.CreateTable(
                name: "MovimientosMoldeadora",
                columns: table => new
                {
                    MovimientoMoldeadoraId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                        .Annotation("Sqlite:Autoincrement", true),
                    Estatus = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    MaterialId = table.Column<int>(nullable: true),
                    ModificadoPorId = table.Column<int>(nullable: true),
                    MoldeId = table.Column<int>(nullable: true),
                    Movimiento = table.Column<string>(nullable: true),
                    NumeroParteId = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosMoldeadora", x => x.MovimientoMoldeadoraId);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadora_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadora_Usuarios_ModificadoPorId",
                        column: x => x.ModificadoPorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadora_Moldes_MoldeId",
                        column: x => x.MoldeId,
                        principalTable: "Moldes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadora_NumerosParte_NumeroParteId",
                        column: x => x.NumeroParteId,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadora_MaterialId",
                table: "MovimientosMoldeadora",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadora_ModificadoPorId",
                table: "MovimientosMoldeadora",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadora_MoldeId",
                table: "MovimientosMoldeadora",
                column: "MoldeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadora_NumeroParteId",
                table: "MovimientosMoldeadora",
                column: "NumeroParteId");
        }
    }
}
