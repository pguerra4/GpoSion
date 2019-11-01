using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class SetupProduccion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Moldes_Moldeadoras_MaquinaMoldeadoraId",
            //     table: "Moldes");

            // migrationBuilder.DropIndex(
            //     name: "IX_Moldes_MaquinaMoldeadoraId",
            //     table: "Moldes");

            // migrationBuilder.DropColumn(
            //     name: "MaquinaMoldeadoraId",
            //     table: "Moldes");

            migrationBuilder.AddColumn<decimal>(
                name: "Costo",
                table: "NumerosParte",
                type: "decimal(18, 3)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "NumerosParte",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LeyendaPieza",
                table: "NumerosParte",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "NumerosParte",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Peso",
                table: "NumerosParte",
                type: "decimal(18, 4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UrlImagenPieza",
                table: "NumerosParte",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estatus",
                table: "Moldeadoras",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Moldeadoras",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoldeId",
                table: "Moldeadoras",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MoldeadoraNumerosParte",
                columns: table => new
                {
                    MoldeadoraId = table.Column<int>(nullable: false),
                    NoParte = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoldeadoraNumerosParte", x => new { x.MoldeadoraId, x.NoParte });
                    table.ForeignKey(
                        name: "FK_MoldeadoraNumerosParte_Moldeadoras_MoldeadoraId",
                        column: x => x.MoldeadoraId,
                        principalTable: "Moldeadoras",
                        principalColumn: "MoldeadoraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoldeadoraNumerosParte_NumerosParte_NoParte",
                        column: x => x.NoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MoldeNumerosParte",
                columns: table => new
                {
                    MoldeId = table.Column<int>(nullable: false),
                    NoParte = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoldeNumerosParte", x => new { x.MoldeId, x.NoParte });
                    table.ForeignKey(
                        name: "FK_MoldeNumerosParte_Moldes_MoldeId",
                        column: x => x.MoldeId,
                        principalTable: "Moldes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MoldeNumerosParte_NumerosParte_NoParte",
                        column: x => x.NoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosMoldeadora",
                columns: table => new
                {
                    MovimientoMoldeadoraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Movimiento = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ModificadoPorId = table.Column<int>(nullable: true),
                    Estatus = table.Column<string>(nullable: true),
                    MoldeId = table.Column<int>(nullable: true),
                    MaterialId = table.Column<int>(nullable: true),
                    NumeroParteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientosMoldeadora", x => x.MovimientoMoldeadoraId);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadora_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadora_Usuarios_ModificadoPorId",
                        column: x => x.ModificadoPorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadora_Moldes_MoldeId",
                        column: x => x.MoldeId,
                        principalTable: "Moldes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMoldeadora_NumerosParte_NumeroParteId",
                        column: x => x.NumeroParteId,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NumerosParte_MaterialId",
                table: "NumerosParte",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Moldeadoras_MaterialId",
                table: "Moldeadoras",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Moldeadoras_MoldeId",
                table: "Moldeadoras",
                column: "MoldeId");

            migrationBuilder.CreateIndex(
                name: "IX_MoldeadoraNumerosParte_NoParte",
                table: "MoldeadoraNumerosParte",
                column: "NoParte");

            migrationBuilder.CreateIndex(
                name: "IX_MoldeNumerosParte_NoParte",
                table: "MoldeNumerosParte",
                column: "NoParte");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadora_MaterialId",
                table: "MovimientosMoldeadora",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadora_ModificadoPorId",
                table: "MovimientosMoldeadora",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadora_MoldeId",
                table: "MovimientosMoldeadora",
                column: "MoldeId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadora_NumeroParteId",
                table: "MovimientosMoldeadora",
                column: "NumeroParteId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Moldeadoras_Materiales_MaterialId",
            //     table: "Moldeadoras",
            //     column: "MaterialId",
            //     principalTable: "Materiales",
            //     principalColumn: "MaterialId",
            //     onDelete: ReferentialAction.Restrict);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Moldeadoras_Moldes_MoldeId",
            //     table: "Moldeadoras",
            //     column: "MoldeId",
            //     principalTable: "Moldes",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Restrict);

            // migrationBuilder.AddForeignKey(
            //     name: "FK_NumerosParte_Materiales_MaterialId",
            //     table: "NumerosParte",
            //     column: "MaterialId",
            //     principalTable: "Materiales",
            //     principalColumn: "MaterialId",
            //     onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moldeadoras_Materiales_MaterialId",
                table: "Moldeadoras");

            migrationBuilder.DropForeignKey(
                name: "FK_Moldeadoras_Moldes_MoldeId",
                table: "Moldeadoras");

            migrationBuilder.DropForeignKey(
                name: "FK_NumerosParte_Materiales_MaterialId",
                table: "NumerosParte");

            migrationBuilder.DropTable(
                name: "MoldeadoraNumerosParte");

            migrationBuilder.DropTable(
                name: "MoldeNumerosParte");

            migrationBuilder.DropTable(
                name: "MovimientosMoldeadora");

            migrationBuilder.DropIndex(
                name: "IX_NumerosParte_MaterialId",
                table: "NumerosParte");

            migrationBuilder.DropIndex(
                name: "IX_Moldeadoras_MaterialId",
                table: "Moldeadoras");

            migrationBuilder.DropIndex(
                name: "IX_Moldeadoras_MoldeId",
                table: "Moldeadoras");

            migrationBuilder.DropColumn(
                name: "Costo",
                table: "NumerosParte");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "NumerosParte");

            migrationBuilder.DropColumn(
                name: "LeyendaPieza",
                table: "NumerosParte");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "NumerosParte");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "NumerosParte");

            migrationBuilder.DropColumn(
                name: "UrlImagenPieza",
                table: "NumerosParte");

            migrationBuilder.DropColumn(
                name: "Estatus",
                table: "Moldeadoras");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Moldeadoras");

            migrationBuilder.DropColumn(
                name: "MoldeId",
                table: "Moldeadoras");

            migrationBuilder.AddColumn<int>(
                name: "MaquinaMoldeadoraId",
                table: "Moldes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Moldes_MaquinaMoldeadoraId",
                table: "Moldes",
                column: "MaquinaMoldeadoraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moldes_Moldeadoras_MaquinaMoldeadoraId",
                table: "Moldes",
                column: "MaquinaMoldeadoraId",
                principalTable: "Moldeadoras",
                principalColumn: "MoldeadoraId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
