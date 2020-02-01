using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class localidadesExistencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocalidadesMateriales",
                columns: table => new
                {
                    LocalidadId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    Existencia = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    UltimaModificacion = table.Column<DateTime>(nullable: true),
                    CreadoPorId = table.Column<string>(nullable: true),
                    ModificadoPorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalidadesMateriales", x => new { x.LocalidadId, x.MaterialId });
                    table.ForeignKey(
                        name: "FK_LocalidadesMateriales_AspNetUsers_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalidadesMateriales_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidades",
                        principalColumn: "LocalidadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalidadesMateriales_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalidadesMateriales_AspNetUsers_ModificadoPorId",
                        column: x => x.ModificadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LocalidadesNumerosParte",
                columns: table => new
                {
                    LocalidadId = table.Column<int>(nullable: false),
                    NoParte = table.Column<string>(nullable: false),
                    Existencia = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    UltimaModificacion = table.Column<DateTime>(nullable: true),
                    CreadoPorId = table.Column<string>(nullable: true),
                    ModificadoPorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalidadesNumerosParte", x => new { x.LocalidadId, x.NoParte });
                    table.ForeignKey(
                        name: "FK_LocalidadesNumerosParte_AspNetUsers_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalidadesNumerosParte_Localidades_LocalidadId",
                        column: x => x.LocalidadId,
                        principalTable: "Localidades",
                        principalColumn: "LocalidadId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalidadesNumerosParte_AspNetUsers_ModificadoPorId",
                        column: x => x.ModificadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LocalidadesNumerosParte_NumerosParte_NoParte",
                        column: x => x.NoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocalidadesMateriales_CreadoPorId",
                table: "LocalidadesMateriales",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalidadesMateriales_MaterialId",
                table: "LocalidadesMateriales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalidadesMateriales_ModificadoPorId",
                table: "LocalidadesMateriales",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalidadesNumerosParte_CreadoPorId",
                table: "LocalidadesNumerosParte",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalidadesNumerosParte_ModificadoPorId",
                table: "LocalidadesNumerosParte",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalidadesNumerosParte_NoParte",
                table: "LocalidadesNumerosParte",
                column: "NoParte");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocalidadesMateriales");

            migrationBuilder.DropTable(
                name: "LocalidadesNumerosParte");
        }
    }
}
