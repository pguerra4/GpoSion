using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GpoSion.API.Migrations
{
    public partial class SegundaInicializacion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "TiposMaterial",
                columns: table => new
                {
                    TipoMaterialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposMaterial", x => x.TipoMaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    TurnoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoTurno = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.TurnoId);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedida",
                columns: table => new
                {
                    UnidadMedidaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "OrdenesCompra",
                columns: table => new
                {
                    NoOrden = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesCompra", x => x.NoOrden);
                    table.ForeignKey(
                        name: "FK_OrdenesCompra_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequerimientosMaterial",
                columns: table => new
                {
                    RequerimientoMaterialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FechaSolicitud = table.Column<DateTime>(nullable: false),
                    TurnoId = table.Column<int>(nullable: true),
                    JefaLinea = table.Column<string>(nullable: true),
                    Fechaentrega = table.Column<DateTime>(nullable: true),
                    Almacenista = table.Column<string>(nullable: true),
                    Recibio = table.Column<string>(nullable: true),
                    Estatus = table.Column<string>(nullable: true),
                    IsRead = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequerimientosMaterial", x => x.RequerimientoMaterialId);
                    table.ForeignKey(
                        name: "FK_RequerimientosMaterial_Turnos_TurnoId",
                        column: x => x.TurnoId,
                        principalTable: "Turnos",
                        principalColumn: "TurnoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Material = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    UnidadMedidaId = table.Column<int>(nullable: true),
                    TipoMaterialId = table.Column<int>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    UltimaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.MaterialId);
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
                        .Annotation("Sqlite:Autoincrement", true),
                    Molde = table.Column<string>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true),
                    UbicacionAreaId = table.Column<int>(nullable: true),
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
                name: "Recibos",
                columns: table => new
                {
                    ReciboId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoRecibo = table.Column<int>(nullable: false),
                    FechaEntrada = table.Column<DateTime>(nullable: true),
                    HoraEntrada = table.Column<DateTime>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    Transportista = table.Column<string>(nullable: true),
                    FacturaAduanal = table.Column<string>(nullable: true),
                    PedimentoImportacion = table.Column<string>(nullable: true),
                    NoLote = table.Column<string>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: true),
                    Recibio = table.Column<string>(nullable: true),
                    CreadoPorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recibos", x => x.ReciboId);
                    table.ForeignKey(
                        name: "FK_Recibos_Usuarios_CreadoPorId",
                        column: x => x.CreadoPorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recibos_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExistenciasMaterial",
                columns: table => new
                {
                    ExistenciaMaterialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaterialId = table.Column<int>(nullable: true),
                    AreaId = table.Column<int>(nullable: true),
                    Existencia = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
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
                name: "NumerosParte",
                columns: table => new
                {
                    NoParte = table.Column<string>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    LeyendaPieza = table.Column<string>(nullable: true),
                    UrlImagenPieza = table.Column<string>(nullable: true),
                    MaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumerosParte", x => x.NoParte);
                    table.ForeignKey(
                        name: "FK_NumerosParte_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NumerosParte_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Viajeros",
                columns: table => new
                {
                    ViajeroId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    Existencia = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Localidad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Viajeros", x => x.ViajeroId);
                    table.ForeignKey(
                        name: "FK_Viajeros_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moldeadoras",
                columns: table => new
                {
                    MoldeadoraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Clave = table.Column<string>(nullable: true),
                    Estatus = table.Column<string>(nullable: true),
                    MoldeId = table.Column<int>(nullable: true),
                    MaterialId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moldeadoras", x => x.MoldeadoraId);
                    table.ForeignKey(
                        name: "FK_Moldeadoras_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moldeadoras_Moldes_MoldeId",
                        column: x => x.MoldeId,
                        principalTable: "Moldes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialesNumerosParte",
                columns: table => new
                {
                    MaterialId = table.Column<int>(nullable: false),
                    NoParte = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialesNumerosParte", x => new { x.MaterialId, x.NoParte });
                    table.ForeignKey(
                        name: "FK_MaterialesNumerosParte_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MaterialesNumerosParte_NumerosParte_NoParte",
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

            migrationBuilder.CreateTable(
                name: "OrdenCompraDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NoParte1 = table.Column<string>(nullable: true),
                    NoOrden = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18, 4)", nullable: false),
                    PiezasAutorizadas = table.Column<int>(nullable: false),
                    PiezasSurtidas = table.Column<int>(nullable: false),
                    UltimaModificacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompraDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenCompraDetalles_OrdenesCompra_NoOrden",
                        column: x => x.NoOrden,
                        principalTable: "OrdenesCompra",
                        principalColumn: "NoOrden",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenCompraDetalles_NumerosParte_NoParte1",
                        column: x => x.NoParte1,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalleRecibos",
                columns: table => new
                {
                    DetalleReciboId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalCajas = table.Column<int>(nullable: false),
                    CantidadPorCaja = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    Referencia2 = table.Column<string>(nullable: true),
                    ViajeroId = table.Column<int>(nullable: true),
                    ReferenciaCliente = table.Column<string>(nullable: true),
                    ReciboId = table.Column<int>(nullable: true),
                    MaterialId = table.Column<int>(nullable: false),
                    UnidadMedidaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleRecibos", x => x.DetalleReciboId);
                    table.ForeignKey(
                        name: "FK_DetalleRecibos_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_DetalleRecibos_Viajeros_ViajeroId",
                        column: x => x.ViajeroId,
                        principalTable: "Viajeros",
                        principalColumn: "ViajeroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequerimientoMaterialMateriales",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RequerimientoMaterialId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    ViajeroId = table.Column<int>(nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    CantidadEntregada = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    UnidadMedidaId = table.Column<int>(nullable: false),
                    FechaEntrega = table.Column<DateTime>(nullable: true),
                    Estatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequerimientoMaterialMateriales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequerimientoMaterialMateriales_Materiales_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materiales",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequerimientoMaterialMateriales_RequerimientosMaterial_RequerimientoMaterialId",
                        column: x => x.RequerimientoMaterialId,
                        principalTable: "RequerimientosMaterial",
                        principalColumn: "RequerimientoMaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequerimientoMaterialMateriales_UnidadesMedida_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "UnidadesMedida",
                        principalColumn: "UnidadMedidaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequerimientoMaterialMateriales_Viajeros_ViajeroId",
                        column: x => x.ViajeroId,
                        principalTable: "Viajeros",
                        principalColumn: "ViajeroId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "Produccion",
                columns: table => new
                {
                    ProduccionId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    MoldeadoraId = table.Column<int>(nullable: true),
                    Purga = table.Column<decimal>(type: "decimal(18, 4)", nullable: true),
                    Colada = table.Column<decimal>(type: "decimal(18, 4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produccion", x => x.ProduccionId);
                    table.ForeignKey(
                        name: "FK_Produccion_Moldeadoras_MoldeadoraId",
                        column: x => x.MoldeadoraId,
                        principalTable: "Moldeadoras",
                        principalColumn: "MoldeadoraId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MovimientosMaterial",
                columns: table => new
                {
                    MovimientoMaterialId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    MaterialId = table.Column<int>(nullable: true),
                    Cantidad = table.Column<decimal>(type: "decimal(18, 3)", nullable: false),
                    OrigenAreaId = table.Column<int>(nullable: true),
                    DestinoAreaId = table.Column<int>(nullable: true),
                    ModificadoPorId = table.Column<int>(nullable: true),
                    ReciboId = table.Column<int>(nullable: true),
                    ViajeroId = table.Column<int>(nullable: true),
                    RequerimientoMaterialMaterialId = table.Column<int>(nullable: true)
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
                    table.ForeignKey(
                        name: "FK_MovimientosMaterial_RequerimientoMaterialMateriales_RequerimientoMaterialMaterialId",
                        column: x => x.RequerimientoMaterialMaterialId,
                        principalTable: "RequerimientoMaterialMateriales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientosMaterial_Viajeros_ViajeroId",
                        column: x => x.ViajeroId,
                        principalTable: "Viajeros",
                        principalColumn: "ViajeroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProduccionNumerosParte",
                columns: table => new
                {
                    ProduccionNumeroParteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProduccionId = table.Column<int>(nullable: false),
                    NoParte = table.Column<string>(nullable: true),
                    Piezas = table.Column<int>(nullable: false),
                    Scrap = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduccionNumerosParte", x => x.ProduccionNumeroParteId);
                    table.ForeignKey(
                        name: "FK_ProduccionNumerosParte_NumerosParte_NoParte",
                        column: x => x.NoParte,
                        principalTable: "NumerosParte",
                        principalColumn: "NoParte",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProduccionNumerosParte_Produccion_ProduccionId",
                        column: x => x.ProduccionId,
                        principalTable: "Produccion",
                        principalColumn: "ProduccionId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_DetalleRecibos_ViajeroId",
                table: "DetalleRecibos",
                column: "ViajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasMaterial_AreaId",
                table: "ExistenciasMaterial",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ExistenciasMaterial_MaterialId",
                table: "ExistenciasMaterial",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_TipoMaterialId",
                table: "Materiales",
                column: "TipoMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_UnidadMedidaId",
                table: "Materiales",
                column: "UnidadMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialesNumerosParte_NoParte",
                table: "MaterialesNumerosParte",
                column: "NoParte");

            migrationBuilder.CreateIndex(
                name: "IX_MoldeadoraNumerosParte_NoParte",
                table: "MoldeadoraNumerosParte",
                column: "NoParte");

            migrationBuilder.CreateIndex(
                name: "IX_Moldeadoras_MaterialId",
                table: "Moldeadoras",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Moldeadoras_MoldeId",
                table: "Moldeadoras",
                column: "MoldeId");

            migrationBuilder.CreateIndex(
                name: "IX_MoldeNumerosParte_NoParte",
                table: "MoldeNumerosParte",
                column: "NoParte");

            migrationBuilder.CreateIndex(
                name: "IX_Moldes_ClienteId",
                table: "Moldes",
                column: "ClienteId");

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

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_ReciboId",
                table: "MovimientosMaterial",
                column: "ReciboId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_RequerimientoMaterialMaterialId",
                table: "MovimientosMaterial",
                column: "RequerimientoMaterialMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientosMaterial_ViajeroId",
                table: "MovimientosMaterial",
                column: "ViajeroId");

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

            migrationBuilder.CreateIndex(
                name: "IX_NumerosParte_ClienteId",
                table: "NumerosParte",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_NumerosParte_MaterialId",
                table: "NumerosParte",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalles_NoOrden",
                table: "OrdenCompraDetalles",
                column: "NoOrden");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompraDetalles_NoParte1",
                table: "OrdenCompraDetalles",
                column: "NoParte1");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesCompra_ClienteId",
                table: "OrdenesCompra",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Produccion_MoldeadoraId",
                table: "Produccion",
                column: "MoldeadoraId");

            migrationBuilder.CreateIndex(
                name: "IX_ProduccionNumerosParte_NoParte",
                table: "ProduccionNumerosParte",
                column: "NoParte");

            migrationBuilder.CreateIndex(
                name: "IX_ProduccionNumerosParte_ProduccionId",
                table: "ProduccionNumerosParte",
                column: "ProduccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_CreadoPorId",
                table: "Recibos",
                column: "CreadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recibos_ProveedorId",
                table: "Recibos",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientoMaterialMateriales_MaterialId",
                table: "RequerimientoMaterialMateriales",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientoMaterialMateriales_RequerimientoMaterialId",
                table: "RequerimientoMaterialMateriales",
                column: "RequerimientoMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientoMaterialMateriales_UnidadMedidaId",
                table: "RequerimientoMaterialMateriales",
                column: "UnidadMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientoMaterialMateriales_ViajeroId",
                table: "RequerimientoMaterialMateriales",
                column: "ViajeroId");

            migrationBuilder.CreateIndex(
                name: "IX_RequerimientosMaterial_TurnoId",
                table: "RequerimientosMaterial",
                column: "TurnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Viajeros_MaterialId",
                table: "Viajeros",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleRecibos");

            migrationBuilder.DropTable(
                name: "ExistenciasMaterial");

            migrationBuilder.DropTable(
                name: "MaterialesNumerosParte");

            migrationBuilder.DropTable(
                name: "MoldeadoraNumerosParte");

            migrationBuilder.DropTable(
                name: "MoldeNumerosParte");

            migrationBuilder.DropTable(
                name: "MovimientosMaterial");

            migrationBuilder.DropTable(
                name: "MovimientosMoldeadora");

            migrationBuilder.DropTable(
                name: "OrdenCompraDetalles");

            migrationBuilder.DropTable(
                name: "ProduccionNumerosParte");

            migrationBuilder.DropTable(
                name: "Recibos");

            migrationBuilder.DropTable(
                name: "RequerimientoMaterialMateriales");

            migrationBuilder.DropTable(
                name: "OrdenesCompra");

            migrationBuilder.DropTable(
                name: "NumerosParte");

            migrationBuilder.DropTable(
                name: "Produccion");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "RequerimientosMaterial");

            migrationBuilder.DropTable(
                name: "Viajeros");

            migrationBuilder.DropTable(
                name: "Moldeadoras");

            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Moldes");

            migrationBuilder.DropTable(
                name: "TiposMaterial");

            migrationBuilder.DropTable(
                name: "UnidadesMedida");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
