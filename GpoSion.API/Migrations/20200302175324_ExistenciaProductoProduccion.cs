using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class ExistenciaProductoProduccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExistenciasProductoProduccion",
                columns: table => new
                {
                    ExistenciaProductoProduccionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NoParte = table.Column<string>(nullable: false),
                    NumeroParteNoParte = table.Column<string>(nullable: true),
                    PiezasCertificadas = table.Column<int>(nullable: false),
                    PiezasRechazadas = table.Column<int>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    UltimaModificacion = table.Column<DateTime>(nullable: true),
                    CreadoPorId = table.Column<string>(nullable: true),
                    ModificadoPorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistenciasProductoProduccion", x => x.ExistenciaProductoProduccionId);
                    table.UniqueConstraint("AlternateKey_ExistenciaProductoProduccionNoParte", x => x.NoParte);
                    table.ForeignKey(
                        name: "FK_ExistenciasProductoProduccion_AspNetUsers_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExistenciasProductoProduccion_AspNetUsers_ModificadoPorId",
                        column: x => x.ModificadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExistenciasProductoProduccion_NumerosParte_NumeroParteNoParte",
                        column: x => x.NumeroParteNoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasProductoProduccion_CreadoPorId",
                table: "ExistenciasProductoProduccion",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasProductoProduccion_ModificadoPorId",
                table: "ExistenciasProductoProduccion",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasProductoProduccion_NumeroParteNoParte",
                table: "ExistenciasProductoProduccion",
                column: "NumeroParteNoParte");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExistenciasProductoProduccion");
        }
    }
}
