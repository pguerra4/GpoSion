using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class HistorialOrdenesCompra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorialOrdenesCompra",
                columns: table => new
                {
                    HistorialOrdenCompraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Observaciones = table.Column<string>(nullable: true),
                    NoOrden = table.Column<long>(nullable: false),
                    CreadoPorId = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialOrdenesCompra", x => x.HistorialOrdenCompraId);
                    table.ForeignKey(
                        name: "FK_HistorialOrdenesCompra_AspNetUsers_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistorialOrdenesCompra_OrdenesCompra_NoOrden",
                        column: x => x.NoOrden,
                        principalTable: "OrdenesCompra",
                        principalColumn: "NoOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HistorialOrdenesCompra_CreadoPorId",
                table: "HistorialOrdenesCompra",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialOrdenesCompra_NoOrden",
                table: "HistorialOrdenesCompra",
                column: "NoOrden");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorialOrdenesCompra");
        }
    }
}
