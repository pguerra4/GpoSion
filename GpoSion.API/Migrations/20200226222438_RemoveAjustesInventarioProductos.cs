using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class RemoveAjustesInventarioProductos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AjustesInventarioProductos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AjustesInventarioProductos",
                columns: table => new
                {
                    AjusteInventarioProductoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreadoPorId = table.Column<string>(nullable: true),
                    CreadorPorId = table.Column<string>(nullable: true),
                    ExistenciaFinal = table.Column<int>(nullable: false),
                    ExistenciaOriginal = table.Column<int>(nullable: false),
                    ExistenciaProductoId = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    LocalidadNumeroParteId = table.Column<int>(nullable: true),
                    LocalidadNumeroParteLocalidadId = table.Column<int>(nullable: true),
                    LocalidadNumeroParteNoParte = table.Column<string>(nullable: true),
                    Motivo = table.Column<string>(nullable: true)
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
                        name: "FK_AjustesInventarioProductos_LocalidadesNumerosParte_LocalidadNumeroParteLocalidadId_LocalidadNumeroParteNoParte",
                        columns: x => new { x.LocalidadNumeroParteLocalidadId, x.LocalidadNumeroParteNoParte },
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
                name: "IX_AjustesInventarioProductos_LocalidadNumeroParteLocalidadId_LocalidadNumeroParteNoParte",
                table: "AjustesInventarioProductos",
                columns: new[] { "LocalidadNumeroParteLocalidadId", "LocalidadNumeroParteNoParte" });
        }
    }
}
