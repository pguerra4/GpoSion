using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class PlaneacionProduccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaneacionProduccion",
                columns: table => new
                {
                    año = table.Column<int>(nullable: false),
                    semana = table.Column<int>(nullable: false),
                    NoParte = table.Column<string>(nullable: false),
                    cantidad = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    UltimaModificacion = table.Column<DateTime>(nullable: true),
                    CreadoPorId = table.Column<string>(nullable: true),
                    ModificadoPorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneacionProduccion", x => new { x.año, x.semana, x.NoParte });
                    table.UniqueConstraint("AK_PlaneacionProduccion_año_NoParte_semana", x => new { x.año, x.NoParte, x.semana });
                    table.ForeignKey(
                        name: "FK_PlaneacionProduccion_AspNetUsers_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaneacionProduccion_AspNetUsers_ModificadoPorId",
                        column: x => x.ModificadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlaneacionProduccion_NumerosParte_NoParte",
                        column: x => x.NoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaneacionProduccion_CreadoPorId",
                table: "PlaneacionProduccion",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneacionProduccion_ModificadoPorId",
                table: "PlaneacionProduccion",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaneacionProduccion_NoParte",
                table: "PlaneacionProduccion",
                column: "NoParte");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaneacionProduccion");
        }
    }
}
