using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class DropRecibo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleRecibos");

            migrationBuilder.DropTable(
                name: "MovimientosMaterial");

            migrationBuilder.DropTable(
                name: "Recibos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    ReciboId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: true),
                    CredoPorId = table.Column<int>(nullable: true),
                    FacturaAduanal = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaEntrada = table.Column<DateTime>(nullable: true),
                    HoraEntrada = table.Column<DateTime>(nullable: true),
                    NoRecibo = table.Column<int>(nullable: false),
                    PedimentoImportacion = table.Column<string>(nullable: true),
                    Recibio = table.Column<string>(nullable: true),
                    Transportista = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.ReciboId);
                    table.ForeignKey(
                        name: "FK_Recibos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recibos_Usuarios_CredoPorId",
                        column: x => x.CredoPorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleRecibos",
                columns: table => new
                {
                    DetalleReciboId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CantidadPorCaja = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    MaterialId = table.Column<int>(nullable: true),
                    ReciboId = table.Column<int>(nullable: true),
                    Referencia2 = table.Column<string>(nullable: true),
                    ReferenciaCliente = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    TotalCajas = table.Column<int>(nullable: false),
                    UnidadMedidaId = table.Column<int>(nullable: true),
                    Viajero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleRecibos", x => x.DetalleReciboId);
                    table.ForeignKey(
                        name: "FK_DetalleRecibos_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleRecibos_Recibos_ReciboId",
                        column: x => x.ReciboId,
                        principalTable: "Recibos",
                        principalColumn: "ReciboId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleRecibos_UnidadesMedida_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "UnidadesMedida",
                        principalColumn: "UnidadMedidaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosMaterial",
                columns: table => new
                {
                    MovimientoMaterialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    DestinoAreaId = table.Column<int>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    MaterialId = table.Column<int>(nullable: true),
                    ModificadoPorId = table.Column<int>(nullable: true),
                    OrigenAreaId = table.Column<int>(nullable: true),
                    ReciboId = table.Column<int>(nullable: true),
                    Viajero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosMaterial", x => x.MovimientoMaterialId);
                    table.ForeignKey(
                        name: "FK_MovimientosMaterial_Areas_DestinoAreaId",
                        column: x => x.DestinoAreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMaterial_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMaterial_Usuarios_ModificadoPorId",
                        column: x => x.ModificadoPorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMaterial_Areas_OrigenAreaId",
                        column: x => x.OrigenAreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMaterial_Recibos_ReciboId",
                        column: x => x.ReciboId,
                        principalTable: "Recibos",
                        principalColumn: "ReciboId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRecibos_MaterialId",
                table: "DetalleRecibos",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRecibos_ReciboId",
                table: "DetalleRecibos",
                column: "ReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRecibos_UnidadMedidaId",
                table: "DetalleRecibos",
                column: "UnidadMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_DestinoAreaId",
                table: "MovimientosMaterial",
                column: "DestinoAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_MaterialId",
                table: "MovimientosMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_ModificadoPorId",
                table: "MovimientosMaterial",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_OrigenAreaId",
                table: "MovimientosMaterial",
                column: "OrigenAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_ReciboId",
                table: "MovimientosMaterial",
                column: "ReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ClienteId",
                table: "Recibos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_CredoPorId",
                table: "Recibos",
                column: "CredoPorId");
        }
    }
}
