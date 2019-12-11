using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class OrdenCompraProveedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compradores",
                columns: table => new
                {
                    CompradorId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    RFC = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compradores", x => x.CompradorId);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesCompraProveedores",
                columns: table => new
                {
                    NoOrden = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    CompradorId = table.Column<int>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false),
                    PersonaSolicita = table.Column<string>(nullable: true),
                    Departamento = table.Column<string>(nullable: true),
                    AreaProyecto = table.Column<string>(nullable: true),
                    RazonCompra = table.Column<string>(nullable: true),
                    Compra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesCompraProveedores", x => x.NoOrden);
                    table.ForeignKey(
                        name: "FK_OrdenesCompraProveedores_Compradores_CompradorId",
                        column: x => x.CompradorId,
                        principalTable: "Compradores",
                        principalColumn: "CompradorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesCompraProveedores_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompraProveedorDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaterialId = table.Column<int>(nullable: false),
                    NoOrden = table.Column<int>(nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    PrecioTotal = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    UltimaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompraProveedorDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenCompraProveedorDetalles_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenCompraProveedorDetalles_OrdenesCompraProveedores_NoOrden",
                        column: x => x.NoOrden,
                        principalTable: "OrdenesCompraProveedores",
                        principalColumn: "NoOrden",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraProveedorDetalles_MaterialId",
                table: "OrdenCompraProveedorDetalles",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraProveedorDetalles_NoOrden",
                table: "OrdenCompraProveedorDetalles",
                column: "NoOrden");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraProveedores_CompradorId",
                table: "OrdenesCompraProveedores",
                column: "CompradorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraProveedores_ProveedorId",
                table: "OrdenesCompraProveedores",
                column: "ProveedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenCompraProveedorDetalles");

            migrationBuilder.DropTable(
                name: "OrdenesCompraProveedores");

            migrationBuilder.DropTable(
                name: "Compradores");
        }
    }
}
