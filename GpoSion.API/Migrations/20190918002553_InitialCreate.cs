using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<string>(nullable: true),
                    Abreviatura = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clave = table.Column<string>(nullable: true),
                    Cliente = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UltimaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Moldeadoras",
                columns: table => new
                {
                    MoldeadoraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Clave = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moldeadoras", x => x.MoldeadoraId);
                });

            migrationBuilder.CreateTable(
                name: "TiposMaterial",
                columns: table => new
                {
                    TipoMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMaterial", x => x.TipoMaterialId);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedida",
                columns: table => new
                {
                    UnidadMedidaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Unidad = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.UnidadMedidaId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Usuario = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Paterno = table.Column<string>(nullable: true),
                    Materno = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UltimaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Material = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    UnidadMedidaId = table.Column<int>(nullable: true),
                    TipoMaterialId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UltimaModificacion = table.Column<DateTime>(nullable: false)
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
                name: "Moldes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Molde = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    UbicacionAreaId = table.Column<int>(nullable: true),
                    MaquinaMoldeadoraId = table.Column<int>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UltimaModificacion = table.Column<DateTime>(nullable: false),
                    ModificadoPorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moldes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moldes_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moldes_Moldeadoras_MaquinaMoldeadoraId",
                        column: x => x.MaquinaMoldeadoraId,
                        principalTable: "Moldeadoras",
                        principalColumn: "MoldeadoraId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moldes_Usuarios_ModificadoPorId",
                        column: x => x.ModificadoPorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moldes_Areas_UbicacionAreaId",
                        column: x => x.UbicacionAreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExistenciasMaterial",
                columns: table => new
                {
                    ExistenciaMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialId = table.Column<int>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    Existencia = table.Column<decimal>(type: "decimal(18, 3)", nullable: false)
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
                name: "MovimientosMaterial",
                columns: table => new
                {
                    MovimientoMaterialId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha = table.Column<DateTime>(nullable: false),
                    MaterialId = table.Column<int>(nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    OrigenAreaId = table.Column<int>(nullable: true),
                    DestinoAreaId = table.Column<int>(nullable: true),
                    ModificadoPorId = table.Column<int>(nullable: true)
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
                });

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
                name: "IX_Moldes_ClienteId",
                table: "Moldes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Moldes_MaquinaMoldeadoraId",
                table: "Moldes",
                column: "MaquinaMoldeadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Moldes_ModificadoPorId",
                table: "Moldes",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Moldes_UbicacionAreaId",
                table: "Moldes",
                column: "UbicacionAreaId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExistenciasMaterial");

            migrationBuilder.DropTable(
                name: "Moldes");

            migrationBuilder.DropTable(
                name: "MovimientosMaterial");

            migrationBuilder.DropTable(
                name: "Moldeadoras");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposMaterial");

            migrationBuilder.DropTable(
                name: "UnidadesMedida");
        }
    }
}
