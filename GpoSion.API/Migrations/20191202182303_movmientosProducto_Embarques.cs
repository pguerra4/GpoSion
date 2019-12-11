using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class movmientosProducto_Embarques : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Embarques",
                columns: table => new
                {
                    EmbarqueId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                        .Annotation("Sqlite:Autoincrement", true),
                    Folio = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    LENo = table.Column<string>(nullable: true),
                    Elaboro = table.Column<string>(nullable: true),
                    Recibio = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UltimaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embarques", x => x.EmbarqueId);
                    table.ForeignKey(
                        name: "FK_Embarques_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExistenciasProducto",
                columns: table => new
                {
                    ExistenciaProductoId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoParte = table.Column<string>(nullable: true),
                    PiezasCertificadas = table.Column<int>(nullable: false),
                    PiezasRechazadas = table.Column<int>(nullable: false),
                    UltimaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExistenciasProducto", x => x.ExistenciaProductoId);
                    table.ForeignKey(
                        name: "FK_ExistenciasProducto_NumerosParte_NoParte",
                        column: x => x.NoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetallesEmbarque",
                columns: table => new
                {
                    DetalleEmbarqueId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmbarqueId = table.Column<int>(nullable: false),
                    NoParte = table.Column<string>(nullable: true),
                    NoOrden = table.Column<int>(nullable: true),
                    Cajas = table.Column<int>(nullable: false),
                    PiezasXCaja = table.Column<int>(nullable: false),
                    Entregadas = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesEmbarque", x => x.DetalleEmbarqueId);
                    table.ForeignKey(
                        name: "FK_DetallesEmbarque_Embarques_EmbarqueId",
                        column: x => x.EmbarqueId,
                        principalTable: "Embarques",
                        principalColumn: "EmbarqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesEmbarque_OrdenesCompra_NoOrden",
                        column: x => x.NoOrden,
                        principalTable: "OrdenesCompra",
                        principalColumn: "NoOrden",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetallesEmbarque_NumerosParte_NoParte",
                        column: x => x.NoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosProducto",
                columns: table => new
                {
                    MovimientoProductoId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoParte = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Cajas = table.Column<int>(nullable: false),
                    PiezasXCaja = table.Column<int>(nullable: false),
                    PiezasCertificadas = table.Column<int>(nullable: false),
                    PiezasRechazadas = table.Column<int>(nullable: false),
                    Purga = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    Colada = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    TipoMovimiento = table.Column<string>(nullable: true),
                    Localidad = table.Column<string>(nullable: true),
                    DetalleEmbarqueId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosProducto", x => x.MovimientoProductoId);
                    table.ForeignKey(
                        name: "FK_MovimientosProducto_DetallesEmbarque_DetalleEmbarqueId",
                        column: x => x.DetalleEmbarqueId,
                        principalTable: "DetallesEmbarque",
                        principalColumn: "DetalleEmbarqueId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosProducto_NumerosParte_NoParte",
                        column: x => x.NoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEmbarque_EmbarqueId",
                table: "DetallesEmbarque",
                column: "EmbarqueId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEmbarque_NoOrden",
                table: "DetallesEmbarque",
                column: "NoOrden");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEmbarque_NoParte",
                table: "DetallesEmbarque",
                column: "NoParte");

            migrationBuilder.CreateIndex(
                name: "IX_Embarques_ClienteId",
                table: "Embarques",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasProducto_NoParte",
                table: "ExistenciasProducto",
                column: "NoParte");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosProducto_DetalleEmbarqueId",
                table: "MovimientosProducto",
                column: "DetalleEmbarqueId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosProducto_NoParte",
                table: "MovimientosProducto",
                column: "NoParte");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExistenciasProducto");

            migrationBuilder.DropTable(
                name: "MovimientosProducto");

            migrationBuilder.DropTable(
                name: "DetallesEmbarque");

            migrationBuilder.DropTable(
                name: "Embarques");
        }
    }
}
