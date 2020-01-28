using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class addColumnOrdenCompraDetalleId_HistorialOC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrdenCompraDetalleId",
                table: "HistorialOrdenesCompra",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistorialOrdenesCompra_OrdenCompraDetalleId",
                table: "HistorialOrdenesCompra",
                column: "OrdenCompraDetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistorialOrdenesCompra_OrdenCompraDetalles_OrdenCompraDetalleId",
                table: "HistorialOrdenesCompra",
                column: "OrdenCompraDetalleId",
                principalTable: "OrdenCompraDetalles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistorialOrdenesCompra_OrdenCompraDetalles_OrdenCompraDetalleId",
                table: "HistorialOrdenesCompra");

            migrationBuilder.DropIndex(
                name: "IX_HistorialOrdenesCompra_OrdenCompraDetalleId",
                table: "HistorialOrdenesCompra");

            migrationBuilder.DropColumn(
                name: "OrdenCompraDetalleId",
                table: "HistorialOrdenesCompra");
        }
    }
}
