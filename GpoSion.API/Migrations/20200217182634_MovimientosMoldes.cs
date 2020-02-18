using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class MovimientosMoldes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstatusMolde",
                columns: table => new
                {
                    EstatusMoldeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Estatus = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    UltimaModificacion = table.Column<DateTime>(nullable: true),
                    CreadoPorId = table.Column<string>(nullable: true),
                    ModificadoPorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatusMolde", x => x.EstatusMoldeId);
                    table.ForeignKey(
                        name: "FK_EstatusMolde_AspNetUsers_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EstatusMolde_AspNetUsers_ModificadoPorId",
                        column: x => x.ModificadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosMoldes",
                columns: table => new
                {
                    MovimientoMoldeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MoldeId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    EstatusMoldeId = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    CreadoPorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosMoldes", x => x.MovimientoMoldeId);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldes_AspNetUsers_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldes_EstatusMolde_EstatusMoldeId",
                        column: x => x.EstatusMoldeId,
                        principalTable: "EstatusMolde",
                        principalColumn: "EstatusMoldeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldes_Moldes_MoldeId",
                        column: x => x.MoldeId,
                        principalTable: "Moldes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstatusMolde_CreadoPorId",
                table: "EstatusMolde",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_EstatusMolde_ModificadoPorId",
                table: "EstatusMolde",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldes_CreadoPorId",
                table: "MovimientosMoldes",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldes_EstatusMoldeId",
                table: "MovimientosMoldes",
                column: "EstatusMoldeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldes_MoldeId",
                table: "MovimientosMoldes",
                column: "MoldeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimientosMoldes");

            migrationBuilder.DropTable(
                name: "EstatusMolde");
        }
    }
}
