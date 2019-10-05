using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class RequerimientosMaterial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    TurnoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoTurno = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.TurnoId);
                });

            migrationBuilder.CreateTable(
                name: "RequerimientosMaterial",
                columns: table => new
                {
                    RequerimientoMaterialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaSolicitud = table.Column<DateTime>(nullable: false),
                    TurnoId = table.Column<int>(nullable: true),
                    Fechaentrega = table.Column<DateTime>(nullable: true),
                    Almacenista = table.Column<string>(nullable: true),
                    Recibio = table.Column<string>(nullable: true),
                    Estatus = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequerimientosMaterial", x => x.RequerimientoMaterialId);
                    table.ForeignKey(
                        name: "FK_RequerimientosMaterial_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "TurnoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequerimientoMaterialMateriales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequerimientoMaterialId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    ViajeroId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    UnidadMedidaId = table.Column<int>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: true),
                    Estatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequerimientoMaterialMateriales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequerimientoMaterialMateriales_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequerimientoMaterialMateriales_RequerimientosMaterial_RequerimientoMaterialId",
                        column: x => x.RequerimientoMaterialId,
                        principalTable: "RequerimientosMaterial",
                        principalColumn: "RequerimientoMaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequerimientoMaterialMateriales_UnidadesMedida_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "UnidadesMedida",
                        principalColumn: "UnidadMedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RequerimientoMaterialMateriales_Viajeros_ViajeroId",
                        column: x => x.ViajeroId,
                        principalTable: "Viajeros",
                        principalColumn: "ViajeroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientoMaterialMateriales_MaterialId",
                table: "RequerimientoMaterialMateriales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientoMaterialMateriales_RequerimientoMaterialId",
                table: "RequerimientoMaterialMateriales",
                column: "RequerimientoMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientoMaterialMateriales_UnidadMedidaId",
                table: "RequerimientoMaterialMateriales",
                column: "UnidadMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientoMaterialMateriales_ViajeroId",
                table: "RequerimientoMaterialMateriales",
                column: "ViajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientosMaterial_TurnoId",
                table: "RequerimientosMaterial",
                column: "TurnoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequerimientoMaterialMateriales");

            migrationBuilder.DropTable(
                name: "RequerimientosMaterial");

            migrationBuilder.DropTable(
                name: "Turnos");
        }
    }
}
