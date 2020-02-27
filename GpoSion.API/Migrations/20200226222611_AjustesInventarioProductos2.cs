using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class AjustesInventarioProductos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AjustesInventarioProductos",
                columns: table => new
                {
                    AjusteInventarioProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Motivo = table.Column<string>(nullable: true),
                    CreadoPorId = table.Column<string>(nullable: true),
                    CreadorPorId = table.Column<string>(nullable: true),
                    ExistenciaOriginal = table.Column<int>(nullable: false),
                    ExistenciaFinal = table.Column<int>(nullable: false),
                    ExistenciaProductoId = table.Column<int>(nullable: true),
                    LocalidadId = table.Column<int>(nullable: true),
                    NoParte = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AjustesInventarioProductos", x => x.AjusteInventarioProductoId);
                    table.ForeignKey(
                        name: "FK_AjustesInventarioProductos_AspNetUsers_CreadorPorId",
                        column: x => x.CreadorPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AjustesInventarioProductos_ExistenciasProducto_ExistenciaProductoId",
                        column: x => x.ExistenciaProductoId,
                        principalTable: "ExistenciasProducto",
                        principalColumn: "ExistenciaProductoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AjustesInventarioProductos_LocalidadesNumerosParte_LocalidadId_NoParte",
                        columns: x => new { x.LocalidadId, x.NoParte },
                        principalTable: "LocalidadesNumerosParte",
                        principalColumns: new[] { "LocalidadId", "NoParte" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventarioProductos_CreadorPorId",
                table: "AjustesInventarioProductos",
                column: "CreadorPorId");

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventarioProductos_ExistenciaProductoId",
                table: "AjustesInventarioProductos",
                column: "ExistenciaProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_AjustesInventarioProductos_LocalidadId_NoParte",
                table: "AjustesInventarioProductos",
                columns: new[] { "LocalidadId", "NoParte" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AjustesInventarioProductos");
        }
    }
}
