using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moldes_Usuarios_ModificadoPorId",
                table: "Moldes");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosMaterial_Usuarios_ModificadoPorId",
                table: "MovimientosMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosMoldeadora_Usuarios_ModificadoPorId",
                table: "MovimientosMoldeadora");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosMoldeadora_ModificadoPorId",
                table: "MovimientosMoldeadora");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosMaterial_ModificadoPorId",
                table: "MovimientosMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Moldes_ModificadoPorId",
                table: "Moldes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recibos_Usuarios_CreadoPorId",
                table: "Recibos");

            migrationBuilder.DropIndex(
                name: "IX_Recibos_CreadoPorId",
                table: "Recibos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "Viajeros",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Viajeros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "Viajeros",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Viajeros",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "Turnos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Turnos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "Turnos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Turnos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "TiposMaterial",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "TiposMaterial",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "TiposMaterial",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "TiposMaterial",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "RequerimientosMaterial",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "RequerimientosMaterial",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "RequerimientosMaterial",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "RequerimientosMaterial",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Recibos",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "CreadoPorId",
                table: "Recibos",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "Recibos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Recibos",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Proveedores",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Proveedores",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "Proveedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "Proveedores",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Produccion",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "Produccion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "Produccion",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Produccion",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "OrdenesCompraProveedores",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "OrdenesCompraProveedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "OrdenesCompraProveedores",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "OrdenesCompraProveedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "OrdenesCompra",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "OrdenesCompra",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "OrdenesCompra",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "OrdenesCompra",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "OrdenCompraProveedorDetalles",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "OrdenCompraProveedorDetalles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "OrdenCompraProveedorDetalles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "OrdenCompraProveedorDetalles",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "OrdenCompraDetalles",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "OrdenCompraDetalles",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "OrdenCompraDetalles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "OrdenCompraDetalles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "NumerosParte",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "NumerosParte",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "NumerosParte",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "NumerosParte",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "MovimientosProducto",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "MovimientosProducto",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "MovimientosProducto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "MovimientosProducto",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPorId",
                table: "MovimientosMoldeadora",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "MovimientosMoldeadora",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "MovimientosMoldeadora",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "MovimientosMoldeadora",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPorId",
                table: "MovimientosMaterial",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "MovimientosMaterial",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "MovimientosMaterial",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "MovimientosMaterial",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "MotivosTiempoMuerto",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "MotivosTiempoMuerto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "MotivosTiempoMuerto",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "MotivosTiempoMuerto",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Moldes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "ModificadoPorId",
                table: "Moldes",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Moldes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "Moldes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "Moldeadoras",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Moldeadoras",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "Moldeadoras",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Materiales",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Materiales",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "Materiales",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "Materiales",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "Localidades",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Localidades",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "Localidades",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Localidades",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "ExistenciasProducto",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "ExistenciasProducto",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "ExistenciasProducto",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "ExistenciasProducto",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "ExistenciasMaterial",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "ExistenciasMaterial",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "ExistenciasMaterial",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "ExistenciasMaterial",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Embarques",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Embarques",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "Embarques",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "Embarques",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "DetallesEmbarque",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "DetallesEmbarque",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "DetallesEmbarque",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "DetallesEmbarque",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "DetalleRecibos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "DetalleRecibos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "DetalleRecibos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaModificacion",
                table: "DetalleRecibos",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Clientes",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "CreadoPorId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModificadoPorId",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Paterno = table.Column<string>(nullable: true),
                    Materno = table.Column<string>(nullable: true),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: true),
                    UltimaModificacion = table.Column<DateTime>(nullable: true),
                    CreadoPorId = table.Column<string>(nullable: true),
                    ModificadoPorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    RoleId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                        column: x => x.RoleId1,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Viajeros_CreadoPorId",
                table: "Viajeros",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajeros_ModificadoPorId",
                table: "Viajeros",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_CreadoPorId",
                table: "Turnos",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_ModificadoPorId",
                table: "Turnos",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposMaterial_CreadoPorId",
                table: "TiposMaterial",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposMaterial_ModificadoPorId",
                table: "TiposMaterial",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientosMaterial_CreadoPorId",
                table: "RequerimientosMaterial",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientosMaterial_ModificadoPorId",
                table: "RequerimientosMaterial",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ModificadoPorId",
                table: "Recibos",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_CreadoPorId",
                table: "Proveedores",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_ModificadoPorId",
                table: "Proveedores",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produccion_CreadoPorId",
                table: "Produccion",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produccion_ModificadoPorId",
                table: "Produccion",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraProveedores_CreadoPorId",
                table: "OrdenesCompraProveedores",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompraProveedores_ModificadoPorId",
                table: "OrdenesCompraProveedores",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_CreadoPorId",
                table: "OrdenesCompra",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_ModificadoPorId",
                table: "OrdenesCompra",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraProveedorDetalles_CreadoPorId",
                table: "OrdenCompraProveedorDetalles",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraProveedorDetalles_ModificadoPorId",
                table: "OrdenCompraProveedorDetalles",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalles_CreadoPorId",
                table: "OrdenCompraDetalles",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalles_ModificadoPorId",
                table: "OrdenCompraDetalles",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_NumerosParte_CreadoPorId",
                table: "NumerosParte",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_NumerosParte_ModificadoPorId",
                table: "NumerosParte",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosProducto_CreadoPorId",
                table: "MovimientosProducto",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosProducto_ModificadoPorId",
                table: "MovimientosProducto",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMoldeadora_CreadoPorId",
                table: "MovimientosMoldeadora",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_CreadoPorId",
                table: "MovimientosMaterial",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MotivosTiempoMuerto_CreadoPorId",
                table: "MotivosTiempoMuerto",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_MotivosTiempoMuerto_ModificadoPorId",
                table: "MotivosTiempoMuerto",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Moldes_CreadoPorId",
                table: "Moldes",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Moldeadoras_CreadoPorId",
                table: "Moldeadoras",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Moldeadoras_ModificadoPorId",
                table: "Moldeadoras",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_CreadoPorId",
                table: "Materiales",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_ModificadoPorId",
                table: "Materiales",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_CreadoPorId",
                table: "Localidades",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Localidades_ModificadoPorId",
                table: "Localidades",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasProducto_CreadoPorId",
                table: "ExistenciasProducto",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasProducto_ModificadoPorId",
                table: "ExistenciasProducto",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasMaterial_CreadoPorId",
                table: "ExistenciasMaterial",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasMaterial_ModificadoPorId",
                table: "ExistenciasMaterial",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Embarques_CreadoPorId",
                table: "Embarques",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Embarques_ModificadoPorId",
                table: "Embarques",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEmbarque_CreadoPorId",
                table: "DetallesEmbarque",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesEmbarque_ModificadoPorId",
                table: "DetallesEmbarque",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRecibos_CreadoPorId",
                table: "DetalleRecibos",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleRecibos_ModificadoPorId",
                table: "DetalleRecibos",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CreadoPorId",
                table: "Clientes",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ModificadoPorId",
                table: "Clientes",
                column: "ModificadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreadoPorId",
                table: "AspNetUsers",
                column: "CreadoPorId",
                unique: true,
                filter: "[CreadoPorId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_CreadoPorId",
                table: "Clientes",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_AspNetUsers_ModificadoPorId",
                table: "Clientes",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleRecibos_AspNetUsers_CreadoPorId",
                table: "DetalleRecibos",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalleRecibos_AspNetUsers_ModificadoPorId",
                table: "DetalleRecibos",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEmbarque_AspNetUsers_CreadoPorId",
                table: "DetallesEmbarque",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DetallesEmbarque_AspNetUsers_ModificadoPorId",
                table: "DetallesEmbarque",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Embarques_AspNetUsers_CreadoPorId",
                table: "Embarques",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Embarques_AspNetUsers_ModificadoPorId",
                table: "Embarques",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasMaterial_AspNetUsers_CreadoPorId",
                table: "ExistenciasMaterial",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasMaterial_AspNetUsers_ModificadoPorId",
                table: "ExistenciasMaterial",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasProducto_AspNetUsers_CreadoPorId",
                table: "ExistenciasProducto",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExistenciasProducto_AspNetUsers_ModificadoPorId",
                table: "ExistenciasProducto",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_AspNetUsers_CreadoPorId",
                table: "Localidades",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Localidades_AspNetUsers_ModificadoPorId",
                table: "Localidades",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materiales_AspNetUsers_CreadoPorId",
                table: "Materiales",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Materiales_AspNetUsers_ModificadoPorId",
                table: "Materiales",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Moldeadoras_AspNetUsers_CreadoPorId",
                table: "Moldeadoras",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Moldeadoras_AspNetUsers_ModificadoPorId",
                table: "Moldeadoras",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Moldes_AspNetUsers_CreadoPorId",
                table: "Moldes",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Moldes_AspNetUsers_ModificadoPorId",
                table: "Moldes",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotivosTiempoMuerto_AspNetUsers_CreadoPorId",
                table: "MotivosTiempoMuerto",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MotivosTiempoMuerto_AspNetUsers_ModificadoPorId",
                table: "MotivosTiempoMuerto",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosMaterial_AspNetUsers_CreadoPorId",
                table: "MovimientosMaterial",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosMaterial_AspNetUsers_ModificadoPorId",
                table: "MovimientosMaterial",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosMoldeadora_AspNetUsers_CreadoPorId",
                table: "MovimientosMoldeadora",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosMoldeadora_AspNetUsers_ModificadoPorId",
                table: "MovimientosMoldeadora",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosProducto_AspNetUsers_CreadoPorId",
                table: "MovimientosProducto",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosProducto_AspNetUsers_ModificadoPorId",
                table: "MovimientosProducto",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumerosParte_AspNetUsers_CreadoPorId",
                table: "NumerosParte",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NumerosParte_AspNetUsers_ModificadoPorId",
                table: "NumerosParte",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompraDetalles_AspNetUsers_CreadoPorId",
                table: "OrdenCompraDetalles",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompraDetalles_AspNetUsers_ModificadoPorId",
                table: "OrdenCompraDetalles",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompraProveedorDetalles_AspNetUsers_CreadoPorId",
                table: "OrdenCompraProveedorDetalles",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenCompraProveedorDetalles_AspNetUsers_ModificadoPorId",
                table: "OrdenCompraProveedorDetalles",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesCompra_AspNetUsers_CreadoPorId",
                table: "OrdenesCompra",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesCompra_AspNetUsers_ModificadoPorId",
                table: "OrdenesCompra",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesCompraProveedores_AspNetUsers_CreadoPorId",
                table: "OrdenesCompraProveedores",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdenesCompraProveedores_AspNetUsers_ModificadoPorId",
                table: "OrdenesCompraProveedores",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produccion_AspNetUsers_CreadoPorId",
                table: "Produccion",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Produccion_AspNetUsers_ModificadoPorId",
                table: "Produccion",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_AspNetUsers_CreadoPorId",
                table: "Proveedores",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proveedores_AspNetUsers_ModificadoPorId",
                table: "Proveedores",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recibos_AspNetUsers_CreadoPorId",
                table: "Recibos",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recibos_AspNetUsers_ModificadoPorId",
                table: "Recibos",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequerimientosMaterial_AspNetUsers_CreadoPorId",
                table: "RequerimientosMaterial",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RequerimientosMaterial_AspNetUsers_ModificadoPorId",
                table: "RequerimientosMaterial",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TiposMaterial_AspNetUsers_CreadoPorId",
                table: "TiposMaterial",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TiposMaterial_AspNetUsers_ModificadoPorId",
                table: "TiposMaterial",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_AspNetUsers_CreadoPorId",
                table: "Turnos",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Turnos_AspNetUsers_ModificadoPorId",
                table: "Turnos",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajeros_AspNetUsers_CreadoPorId",
                table: "Viajeros",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Viajeros_AspNetUsers_ModificadoPorId",
                table: "Viajeros",
                column: "ModificadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AspNetUsers_CreadoPorId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_AspNetUsers_ModificadoPorId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleRecibos_AspNetUsers_CreadoPorId",
                table: "DetalleRecibos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalleRecibos_AspNetUsers_ModificadoPorId",
                table: "DetalleRecibos");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEmbarque_AspNetUsers_CreadoPorId",
                table: "DetallesEmbarque");

            migrationBuilder.DropForeignKey(
                name: "FK_DetallesEmbarque_AspNetUsers_ModificadoPorId",
                table: "DetallesEmbarque");

            migrationBuilder.DropForeignKey(
                name: "FK_Embarques_AspNetUsers_CreadoPorId",
                table: "Embarques");

            migrationBuilder.DropForeignKey(
                name: "FK_Embarques_AspNetUsers_ModificadoPorId",
                table: "Embarques");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasMaterial_AspNetUsers_CreadoPorId",
                table: "ExistenciasMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasMaterial_AspNetUsers_ModificadoPorId",
                table: "ExistenciasMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasProducto_AspNetUsers_CreadoPorId",
                table: "ExistenciasProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_ExistenciasProducto_AspNetUsers_ModificadoPorId",
                table: "ExistenciasProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_AspNetUsers_CreadoPorId",
                table: "Localidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Localidades_AspNetUsers_ModificadoPorId",
                table: "Localidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Materiales_AspNetUsers_CreadoPorId",
                table: "Materiales");

            migrationBuilder.DropForeignKey(
                name: "FK_Materiales_AspNetUsers_ModificadoPorId",
                table: "Materiales");

            migrationBuilder.DropForeignKey(
                name: "FK_Moldeadoras_AspNetUsers_CreadoPorId",
                table: "Moldeadoras");

            migrationBuilder.DropForeignKey(
                name: "FK_Moldeadoras_AspNetUsers_ModificadoPorId",
                table: "Moldeadoras");

            migrationBuilder.DropForeignKey(
                name: "FK_Moldes_AspNetUsers_CreadoPorId",
                table: "Moldes");

            migrationBuilder.DropForeignKey(
                name: "FK_Moldes_AspNetUsers_ModificadoPorId",
                table: "Moldes");

            migrationBuilder.DropForeignKey(
                name: "FK_MotivosTiempoMuerto_AspNetUsers_CreadoPorId",
                table: "MotivosTiempoMuerto");

            migrationBuilder.DropForeignKey(
                name: "FK_MotivosTiempoMuerto_AspNetUsers_ModificadoPorId",
                table: "MotivosTiempoMuerto");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosMaterial_AspNetUsers_CreadoPorId",
                table: "MovimientosMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosMaterial_AspNetUsers_ModificadoPorId",
                table: "MovimientosMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosMoldeadora_AspNetUsers_CreadoPorId",
                table: "MovimientosMoldeadora");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosMoldeadora_AspNetUsers_ModificadoPorId",
                table: "MovimientosMoldeadora");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosProducto_AspNetUsers_CreadoPorId",
                table: "MovimientosProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_MovimientosProducto_AspNetUsers_ModificadoPorId",
                table: "MovimientosProducto");

            migrationBuilder.DropForeignKey(
                name: "FK_NumerosParte_AspNetUsers_CreadoPorId",
                table: "NumerosParte");

            migrationBuilder.DropForeignKey(
                name: "FK_NumerosParte_AspNetUsers_ModificadoPorId",
                table: "NumerosParte");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompraDetalles_AspNetUsers_CreadoPorId",
                table: "OrdenCompraDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompraDetalles_AspNetUsers_ModificadoPorId",
                table: "OrdenCompraDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompraProveedorDetalles_AspNetUsers_CreadoPorId",
                table: "OrdenCompraProveedorDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenCompraProveedorDetalles_AspNetUsers_ModificadoPorId",
                table: "OrdenCompraProveedorDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesCompra_AspNetUsers_CreadoPorId",
                table: "OrdenesCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesCompra_AspNetUsers_ModificadoPorId",
                table: "OrdenesCompra");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesCompraProveedores_AspNetUsers_CreadoPorId",
                table: "OrdenesCompraProveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_OrdenesCompraProveedores_AspNetUsers_ModificadoPorId",
                table: "OrdenesCompraProveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Produccion_AspNetUsers_CreadoPorId",
                table: "Produccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Produccion_AspNetUsers_ModificadoPorId",
                table: "Produccion");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_AspNetUsers_CreadoPorId",
                table: "Proveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Proveedores_AspNetUsers_ModificadoPorId",
                table: "Proveedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Recibos_AspNetUsers_CreadoPorId",
                table: "Recibos");

            migrationBuilder.DropForeignKey(
                name: "FK_Recibos_AspNetUsers_ModificadoPorId",
                table: "Recibos");

            migrationBuilder.DropForeignKey(
                name: "FK_RequerimientosMaterial_AspNetUsers_CreadoPorId",
                table: "RequerimientosMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_RequerimientosMaterial_AspNetUsers_ModificadoPorId",
                table: "RequerimientosMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_TiposMaterial_AspNetUsers_CreadoPorId",
                table: "TiposMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_TiposMaterial_AspNetUsers_ModificadoPorId",
                table: "TiposMaterial");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_AspNetUsers_CreadoPorId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Turnos_AspNetUsers_ModificadoPorId",
                table: "Turnos");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajeros_AspNetUsers_CreadoPorId",
                table: "Viajeros");

            migrationBuilder.DropForeignKey(
                name: "FK_Viajeros_AspNetUsers_ModificadoPorId",
                table: "Viajeros");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_Viajeros_CreadoPorId",
                table: "Viajeros");

            migrationBuilder.DropIndex(
                name: "IX_Viajeros_ModificadoPorId",
                table: "Viajeros");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_CreadoPorId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_Turnos_ModificadoPorId",
                table: "Turnos");

            migrationBuilder.DropIndex(
                name: "IX_TiposMaterial_CreadoPorId",
                table: "TiposMaterial");

            migrationBuilder.DropIndex(
                name: "IX_TiposMaterial_ModificadoPorId",
                table: "TiposMaterial");

            migrationBuilder.DropIndex(
                name: "IX_RequerimientosMaterial_CreadoPorId",
                table: "RequerimientosMaterial");

            migrationBuilder.DropIndex(
                name: "IX_RequerimientosMaterial_ModificadoPorId",
                table: "RequerimientosMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Recibos_ModificadoPorId",
                table: "Recibos");

            migrationBuilder.DropIndex(
                name: "IX_Proveedores_CreadoPorId",
                table: "Proveedores");

            migrationBuilder.DropIndex(
                name: "IX_Proveedores_ModificadoPorId",
                table: "Proveedores");

            migrationBuilder.DropIndex(
                name: "IX_Produccion_CreadoPorId",
                table: "Produccion");

            migrationBuilder.DropIndex(
                name: "IX_Produccion_ModificadoPorId",
                table: "Produccion");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesCompraProveedores_CreadoPorId",
                table: "OrdenesCompraProveedores");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesCompraProveedores_ModificadoPorId",
                table: "OrdenesCompraProveedores");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesCompra_CreadoPorId",
                table: "OrdenesCompra");

            migrationBuilder.DropIndex(
                name: "IX_OrdenesCompra_ModificadoPorId",
                table: "OrdenesCompra");

            migrationBuilder.DropIndex(
                name: "IX_OrdenCompraProveedorDetalles_CreadoPorId",
                table: "OrdenCompraProveedorDetalles");

            migrationBuilder.DropIndex(
                name: "IX_OrdenCompraProveedorDetalles_ModificadoPorId",
                table: "OrdenCompraProveedorDetalles");

            migrationBuilder.DropIndex(
                name: "IX_OrdenCompraDetalles_CreadoPorId",
                table: "OrdenCompraDetalles");

            migrationBuilder.DropIndex(
                name: "IX_OrdenCompraDetalles_ModificadoPorId",
                table: "OrdenCompraDetalles");

            migrationBuilder.DropIndex(
                name: "IX_NumerosParte_CreadoPorId",
                table: "NumerosParte");

            migrationBuilder.DropIndex(
                name: "IX_NumerosParte_ModificadoPorId",
                table: "NumerosParte");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosProducto_CreadoPorId",
                table: "MovimientosProducto");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosProducto_ModificadoPorId",
                table: "MovimientosProducto");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosMoldeadora_CreadoPorId",
                table: "MovimientosMoldeadora");

            migrationBuilder.DropIndex(
                name: "IX_MovimientosMaterial_CreadoPorId",
                table: "MovimientosMaterial");

            migrationBuilder.DropIndex(
                name: "IX_MotivosTiempoMuerto_CreadoPorId",
                table: "MotivosTiempoMuerto");

            migrationBuilder.DropIndex(
                name: "IX_MotivosTiempoMuerto_ModificadoPorId",
                table: "MotivosTiempoMuerto");

            migrationBuilder.DropIndex(
                name: "IX_Moldes_CreadoPorId",
                table: "Moldes");

            migrationBuilder.DropIndex(
                name: "IX_Moldeadoras_CreadoPorId",
                table: "Moldeadoras");

            migrationBuilder.DropIndex(
                name: "IX_Moldeadoras_ModificadoPorId",
                table: "Moldeadoras");

            migrationBuilder.DropIndex(
                name: "IX_Materiales_CreadoPorId",
                table: "Materiales");

            migrationBuilder.DropIndex(
                name: "IX_Materiales_ModificadoPorId",
                table: "Materiales");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_CreadoPorId",
                table: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_Localidades_ModificadoPorId",
                table: "Localidades");

            migrationBuilder.DropIndex(
                name: "IX_ExistenciasProducto_CreadoPorId",
                table: "ExistenciasProducto");

            migrationBuilder.DropIndex(
                name: "IX_ExistenciasProducto_ModificadoPorId",
                table: "ExistenciasProducto");

            migrationBuilder.DropIndex(
                name: "IX_ExistenciasMaterial_CreadoPorId",
                table: "ExistenciasMaterial");

            migrationBuilder.DropIndex(
                name: "IX_ExistenciasMaterial_ModificadoPorId",
                table: "ExistenciasMaterial");

            migrationBuilder.DropIndex(
                name: "IX_Embarques_CreadoPorId",
                table: "Embarques");

            migrationBuilder.DropIndex(
                name: "IX_Embarques_ModificadoPorId",
                table: "Embarques");

            migrationBuilder.DropIndex(
                name: "IX_DetallesEmbarque_CreadoPorId",
                table: "DetallesEmbarque");

            migrationBuilder.DropIndex(
                name: "IX_DetallesEmbarque_ModificadoPorId",
                table: "DetallesEmbarque");

            migrationBuilder.DropIndex(
                name: "IX_DetalleRecibos_CreadoPorId",
                table: "DetalleRecibos");

            migrationBuilder.DropIndex(
                name: "IX_DetalleRecibos_ModificadoPorId",
                table: "DetalleRecibos");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CreadoPorId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ModificadoPorId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Viajeros");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Viajeros");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Viajeros");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "Viajeros");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "Turnos");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "TiposMaterial");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "TiposMaterial");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "TiposMaterial");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "TiposMaterial");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "RequerimientosMaterial");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "RequerimientosMaterial");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "RequerimientosMaterial");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "RequerimientosMaterial");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Recibos");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "Recibos");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Produccion");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Produccion");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "Produccion");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "OrdenesCompraProveedores");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "OrdenesCompraProveedores");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "OrdenesCompraProveedores");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "OrdenesCompraProveedores");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "OrdenesCompra");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "OrdenesCompra");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "OrdenesCompra");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "OrdenesCompra");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "OrdenCompraProveedorDetalles");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "OrdenCompraProveedorDetalles");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "OrdenCompraProveedorDetalles");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "OrdenCompraDetalles");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "OrdenCompraDetalles");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "OrdenCompraDetalles");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "NumerosParte");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "NumerosParte");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "NumerosParte");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "NumerosParte");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "MovimientosProducto");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "MovimientosProducto");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "MovimientosMoldeadora");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "MovimientosMoldeadora");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "MovimientosMoldeadora");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "MovimientosMaterial");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "MovimientosMaterial");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "MovimientosMaterial");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "MotivosTiempoMuerto");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "MotivosTiempoMuerto");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "MotivosTiempoMuerto");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "MotivosTiempoMuerto");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Moldes");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Moldeadoras");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Moldeadoras");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Moldeadoras");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Materiales");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Materiales");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "Localidades");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "ExistenciasProducto");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "ExistenciasProducto");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "ExistenciasProducto");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "ExistenciasMaterial");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "ExistenciasMaterial");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "ExistenciasMaterial");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Embarques");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Embarques");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "DetallesEmbarque");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "DetallesEmbarque");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "DetallesEmbarque");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "DetallesEmbarque");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "DetalleRecibos");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "DetalleRecibos");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "DetalleRecibos");

            migrationBuilder.DropColumn(
                name: "UltimaModificacion",
                table: "DetalleRecibos");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ModificadoPorId",
                table: "Clientes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Recibos",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreadoPorId",
                table: "Recibos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Proveedores",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Proveedores",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Produccion",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "OrdenCompraProveedorDetalles",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "OrdenCompraDetalles",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "MovimientosProducto",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "MovimientosProducto",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModificadoPorId",
                table: "MovimientosMoldeadora",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModificadoPorId",
                table: "MovimientosMaterial",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Moldes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ModificadoPorId",
                table: "Moldes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Moldes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Materiales",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Materiales",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "ExistenciasProducto",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "ExistenciasMaterial",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Embarques",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Embarques",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UltimaModificacion",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activo = table.Column<bool>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    Materno = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Paterno = table.Column<string>(nullable: true),
                    UltimaModificacion = table.Column<DateTime>(nullable: false),
                    Usuario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Moldes_Usuarios_ModificadoPorId",
                table: "Moldes",
                column: "ModificadoPorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosMaterial_Usuarios_ModificadoPorId",
                table: "MovimientosMaterial",
                column: "ModificadoPorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovimientosMoldeadora_Usuarios_ModificadoPorId",
                table: "MovimientosMoldeadora",
                column: "ModificadoPorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recibos_Usuarios_CreadoPorId",
                table: "Recibos",
                column: "CreadoPorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
