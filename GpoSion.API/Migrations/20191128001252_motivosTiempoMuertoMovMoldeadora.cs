using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class motivosTiempoMuertoMovMoldeadora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MotivosTiempoMuerto",
                columns: table => new
                {
                    MotivoTiempoMuertoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Motivo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosTiempoMuerto", x => x.MotivoTiempoMuertoId);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosMoldeadora",
                columns: table => new
                {
                    MovimientoMoldeadoraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MoldeadoraId = table.Column<int>(nullable: false),
                    Movimiento = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ModificadoPorId = table.Column<int>(nullable: true),
                    Estatus = table.Column<string>(nullable: true),
                    MoldeId = table.Column<int>(nullable: true),
                    MaterialId = table.Column<int>(nullable: true),
                    MotivoTiempoMuertoId = table.Column<int>(nullable: true)
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
                        name: "FK_MovimientosMoldeadora_Moldeadoras_MoldeadoraId",
                        column: x => x.MoldeadoraId,
                        principalTable: "Moldeadoras",
                        principalColumn: "MoldeadoraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadora_MotivosTiempoMuerto_MotivoTiempoMuertoId",
                        column: x => x.MotivoTiempoMuertoId,
                        principalTable: "MotivosTiempoMuerto",
                        principalColumn: "MotivoTiempoMuertoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosMoldeadoraNumerosParte",
                columns: table => new
                {
                    MovimientoMoldeadoraId = table.Column<int>(nullable: false),
                    NoParte = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosMoldeadoraNumerosParte", x => new { x.MovimientoMoldeadoraId, x.NoParte });
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadoraNumerosParte_MovimientosMoldeadora_MovimientoMoldeadoraId",
                        column: x => x.MovimientoMoldeadoraId,
                        principalTable: "MovimientosMoldeadora",
                        principalColumn: "MovimientoMoldeadoraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadoraNumerosParte_NumerosParte_NoParte",
                        column: x => x.NoParte,
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
                name: "IX_MovimientosMoldeadora_MoldeadoraId",
                table: "MovimientosMoldeadora",
                column: "MoldeadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadora_MotivoTiempoMuertoId",
                table: "MovimientosMoldeadora",
                column: "MotivoTiempoMuertoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadoraNumerosParte_NoParte",
                table: "MovimientosMoldeadoraNumerosParte",
                column: "NoParte");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimientosMoldeadoraNumerosParte");

            migrationBuilder.DropTable(
                name: "MovimientosMoldeadora");

            migrationBuilder.DropTable(
                name: "MotivosTiempoMuerto");
        }
    }
}
