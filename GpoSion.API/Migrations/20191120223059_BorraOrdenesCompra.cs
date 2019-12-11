using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class BorraOrdenesCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenCompraDetalles");

            migrationBuilder.DropTable(
                name: "OrdenesCompra");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrdenesCompra",
                columns: table => new
                {
                    NoOrden = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesCompra", x => x.NoOrden);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompraDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaFin = table.Column<DateTime>(nullable: true),
                    FechaInicio = table.Column<DateTime>(nullable: true),
                    NoOrden = table.Column<int>(nullable: false),
                    NoParte1 = table.Column<string>(nullable: true),
                    PiezasAutorizadas = table.Column<int>(nullable: false),
                    PiezasSurtidas = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    UltimaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompraDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenCompraDetalles_OrdenesCompra_NoOrden",
                        column: x => x.NoOrden,
                        principalTable: "OrdenesCompra",
                        principalColumn: "NoOrden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenCompraDetalles_NumerosParte_NoParte1",
                        column: x => x.NoParte1,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalles_NoOrden",
                table: "OrdenCompraDetalles",
                column: "NoOrden");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalles_NoParte1",
                table: "OrdenCompraDetalles",
                column: "NoParte1");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_ClienteId",
                table: "OrdenesCompra",
                column: "ClienteId");
        }
    }
}
