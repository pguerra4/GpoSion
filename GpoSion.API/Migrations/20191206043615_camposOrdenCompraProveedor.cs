using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class camposOrdenCompraProveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CondicionesCredito",
                table: "Proveedores",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaEntrega",
                table: "OrdenesCompraProveedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadMedida",
                table: "OrdenCompraProveedorDetalles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CondicionesCredito",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "FechaEntrega",
                table: "OrdenesCompraProveedores");

            migrationBuilder.DropColumn(
                name: "UnidadMedida",
                table: "OrdenCompraProveedorDetalles");
        }
    }
}
