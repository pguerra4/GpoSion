using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class OrdenesCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NumerosParte",
                columns: table => new
                {
                    NoParte = table.Column<string>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumerosParte", x => x.NoParte);
                    table.ForeignKey(
                        name: "FK_NumerosParte_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesCompra",
                columns: table => new
                {
                    NoOrden = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesCompra", x => x.NoOrden);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompraDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoParte = table.Column<string>(nullable: true),
                    NoOrden = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    PiezasAutorizadas = table.Column<int>(nullable: false),
                    PiezasSurtidas = table.Column<int>(nullable: false),
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
                        column: x => x.NoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumerosParte_ClienteId",
                table: "NumerosParte",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalles_NoOrden",
                table: "OrdenCompraDetalles",
                column: "NoOrden");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalles_NoParte",
                table: "OrdenCompraDetalles",
                column: "NoParte");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_ClienteId",
                table: "OrdenesCompra",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenCompraDetalles");

            migrationBuilder.DropTable(
                name: "OrdenesCompra");

            migrationBuilder.DropTable(
                name: "NumerosParte");
        }
    }
}
