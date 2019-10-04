using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class RecreateSomeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleRecibos");

            migrationBuilder.DropTable(
                name: "ExistenciasMaterial");

            migrationBuilder.DropTable(
                name: "MovimientosMaterial");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Recibos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Material = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    TipoMaterialId = table.Column<int>(nullable: true),
                    UltimaModificacion = table.Column<DateTime>(nullable: false),
                    UnidadMedidaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.MaterialId);
                    table.ForeignKey(
                        name: "FK_Materiales_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materiales_TiposMaterial_TipoMaterialId",
                        column: x => x.TipoMaterialId,
                        principalTable: "TiposMaterial",
                        principalColumn: "TipoMaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materiales_UnidadesMedida_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "UnidadesMedida",
                        principalColumn: "UnidadMedidaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recibos",
                columns: table => new
                {
                    ReciboId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: true),
                    CreadoPorId = table.Column<int>(nullable: true),
                    FacturaAduanal = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    FechaEntrada = table.Column<DateTime>(nullable: true),
                    HoraEntrada = table.Column<DateTime>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
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
                        name: "FK_Recibos_Usuarios_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExistenciasMaterial",
                columns: table => new
                {
                    ExistenciaMaterialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AreaId = table.Column<int>(nullable: true),
                    Existencia = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    MaterialId = table.Column<int>(nullable: true),
                    UltimaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistenciasMaterial", x => x.ExistenciaMaterialId);
                    table.ForeignKey(
                        name: "FK_ExistenciasMaterial_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExistenciasMaterial_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
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
                name: "IX_ExistenciasMaterial_AreaId",
                table: "ExistenciasMaterial",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasMaterial_MaterialId",
                table: "ExistenciasMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_ClienteId",
                table: "Materiales",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_TipoMaterialId",
                table: "Materiales",
                column: "TipoMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_UnidadMedidaId",
                table: "Materiales",
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
                name: "IX_Recibos_CreadoPorId",
                table: "Recibos",
                column: "CreadoPorId");
        }
    }
}
