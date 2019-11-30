﻿// <auto-generated />
using System;
using GpoSion.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GpoSion.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191129161817_clientes_proveedores")]
    partial class clientes_proveedores
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("GpoSion.API.Models.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Abreviatura");

                    b.Property<string>("NombreArea")
                        .HasColumnName("Area");

                    b.HasKey("AreaId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("GpoSion.API.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Clave");

                    b.Property<string>("Direccion");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<string>("Nombre")
                        .HasColumnName("Cliente");

                    b.Property<string>("Telefono");

                    b.Property<DateTime>("UltimaModificacion");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GpoSion.API.Models.DetalleRecibo", b =>
                {
                    b.Property<int>("DetalleReciboId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("CantidadPorCaja")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int>("MaterialId");

                    b.Property<int?>("ReciboId");

                    b.Property<string>("Referencia2");

                    b.Property<string>("ReferenciaCliente");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int>("TotalCajas");

                    b.Property<int?>("UnidadMedidaId");

                    b.Property<int?>("ViajeroId");

                    b.HasKey("DetalleReciboId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ReciboId");

                    b.HasIndex("UnidadMedidaId");

                    b.HasIndex("ViajeroId");

                    b.ToTable("DetalleRecibos");
                });

            modelBuilder.Entity("GpoSion.API.Models.ExistenciaMaterial", b =>
                {
                    b.Property<int>("ExistenciaMaterialId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AreaId");

                    b.Property<decimal>("Existencia")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int?>("MaterialId");

                    b.Property<DateTime>("UltimaModificacion");

                    b.HasKey("ExistenciaMaterialId");

                    b.HasIndex("AreaId");

                    b.HasIndex("MaterialId");

                    b.ToTable("ExistenciasMaterial");
                });

            modelBuilder.Entity("GpoSion.API.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaveMaterial")
                        .HasColumnName("Material");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<int?>("TipoMaterialId");

                    b.Property<DateTime>("UltimaModificacion");

                    b.Property<int?>("UnidadMedidaId");

                    b.HasKey("MaterialId");

                    b.HasIndex("TipoMaterialId");

                    b.HasIndex("UnidadMedidaId");

                    b.ToTable("Materiales");
                });

            modelBuilder.Entity("GpoSion.API.Models.MaterialNumeroParte", b =>
                {
                    b.Property<int>("MaterialId");

                    b.Property<string>("NoParte");

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("MaterialId", "NoParte");

                    b.HasIndex("NoParte");

                    b.ToTable("MaterialesNumerosParte");
                });

            modelBuilder.Entity("GpoSion.API.Models.Molde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaveMolde")
                        .HasColumnName("Molde");

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<int?>("ModificadoPorId");

                    b.Property<int?>("UbicacionAreaId");

                    b.Property<DateTime>("UltimaModificacion");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ModificadoPorId");

                    b.HasIndex("UbicacionAreaId");

                    b.ToTable("Moldes");
                });

            modelBuilder.Entity("GpoSion.API.Models.MoldeNumeroParte", b =>
                {
                    b.Property<int>("MoldeId");

                    b.Property<string>("NoParte");

                    b.HasKey("MoldeId", "NoParte");

                    b.HasIndex("NoParte");

                    b.ToTable("MoldeNumerosParte");
                });

            modelBuilder.Entity("GpoSion.API.Models.Moldeadora", b =>
                {
                    b.Property<int>("MoldeadoraId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Clave");

                    b.Property<string>("Estatus");

                    b.Property<int?>("MaterialId");

                    b.Property<int?>("MoldeId");

                    b.Property<DateTime?>("UltimaModificacion");

                    b.Property<int?>("UltimoMotivoParo");

                    b.HasKey("MoldeadoraId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("MoldeId");

                    b.ToTable("Moldeadoras");
                });

            modelBuilder.Entity("GpoSion.API.Models.MoldeadoraNumeroParte", b =>
                {
                    b.Property<int>("MoldeadoraId");

                    b.Property<string>("NoParte");

                    b.HasKey("MoldeadoraId", "NoParte");

                    b.HasIndex("NoParte");

                    b.ToTable("MoldeadoraNumerosParte");
                });

            modelBuilder.Entity("GpoSion.API.Models.MotivoTiempoMuerto", b =>
                {
                    b.Property<int>("MotivoTiempoMuertoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Motivo");

                    b.HasKey("MotivoTiempoMuertoId");

                    b.ToTable("MotivosTiempoMuerto");
                });

            modelBuilder.Entity("GpoSion.API.Models.MovimientoMaterial", b =>
                {
                    b.Property<int>("MovimientoMaterialId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int?>("DestinoAreaId");

                    b.Property<DateTime>("Fecha");

                    b.Property<int?>("MaterialId");

                    b.Property<int?>("ModificadoPorId");

                    b.Property<int?>("OrigenAreaId");

                    b.Property<int?>("ReciboId");

                    b.Property<int?>("RequerimientoMaterialMaterialId");

                    b.Property<int?>("ViajeroId");

                    b.HasKey("MovimientoMaterialId");

                    b.HasIndex("DestinoAreaId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ModificadoPorId");

                    b.HasIndex("OrigenAreaId");

                    b.HasIndex("ReciboId");

                    b.HasIndex("RequerimientoMaterialMaterialId");

                    b.HasIndex("ViajeroId");

                    b.ToTable("MovimientosMaterial");
                });

            modelBuilder.Entity("GpoSion.API.Models.MovimientoMoldeadora", b =>
                {
                    b.Property<int>("MovimientoMoldeadoraId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Estatus");

                    b.Property<DateTime>("Fecha");

                    b.Property<int?>("MaterialId");

                    b.Property<int?>("ModificadoPorId");

                    b.Property<int?>("MoldeId");

                    b.Property<int>("MoldeadoraId");

                    b.Property<int?>("MotivoTiempoMuertoId");

                    b.Property<string>("Movimiento");

                    b.Property<string>("Observaciones");

                    b.HasKey("MovimientoMoldeadoraId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ModificadoPorId");

                    b.HasIndex("MoldeId");

                    b.HasIndex("MoldeadoraId");

                    b.HasIndex("MotivoTiempoMuertoId");

                    b.ToTable("MovimientosMoldeadora");
                });

            modelBuilder.Entity("GpoSion.API.Models.MovimientoMoldeadoraNumeroParte", b =>
                {
                    b.Property<int>("MovimientoMoldeadoraId");

                    b.Property<string>("NoParte");

                    b.HasKey("MovimientoMoldeadoraId", "NoParte");

                    b.HasIndex("NoParte");

                    b.ToTable("MovimientosMoldeadoraNumerosParte");
                });

            modelBuilder.Entity("GpoSion.API.Models.NumeroParte", b =>
                {
                    b.Property<string>("NoParte")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<string>("Descripcion");

                    b.Property<string>("LeyendaPieza");

                    b.Property<int?>("MaterialId");

                    b.Property<decimal>("Peso")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<string>("UrlImagenPieza");

                    b.HasKey("NoParte");

                    b.HasIndex("ClienteId");

                    b.HasIndex("MaterialId");

                    b.ToTable("NumerosParte");
                });

            modelBuilder.Entity("GpoSion.API.Models.OrdenCompra", b =>
                {
                    b.Property<int>("NoOrden");

                    b.Property<int>("ClienteId");

                    b.Property<DateTime>("Fecha");

                    b.HasKey("NoOrden");

                    b.HasIndex("ClienteId");

                    b.ToTable("OrdenesCompra");
                });

            modelBuilder.Entity("GpoSion.API.Models.OrdenCompraDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("FechaFin");

                    b.Property<DateTime?>("FechaInicio");

                    b.Property<int>("NoOrden");

                    b.Property<string>("NoParte");

                    b.Property<int>("PiezasAutorizadas");

                    b.Property<int>("PiezasSurtidas");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<DateTime>("UltimaModificacion");

                    b.HasKey("Id");

                    b.HasIndex("NoOrden");

                    b.HasIndex("NoParte");

                    b.ToTable("OrdenCompraDetalles");
                });

            modelBuilder.Entity("GpoSion.API.Models.Produccion", b =>
                {
                    b.Property<int>("ProduccionId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal?>("Colada")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<DateTime>("Fecha");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<int?>("MoldeadoraId");

                    b.Property<decimal?>("Purga")
                        .HasColumnType("decimal(18, 4)");

                    b.HasKey("ProduccionId");

                    b.HasIndex("MoldeadoraId");

                    b.ToTable("Produccion");
                });

            modelBuilder.Entity("GpoSion.API.Models.ProduccionNumeroParte", b =>
                {
                    b.Property<int>("ProduccionNumeroParteId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NoParte");

                    b.Property<int>("Piezas");

                    b.Property<int>("ProduccionId");

                    b.Property<int>("Scrap");

                    b.HasKey("ProduccionNumeroParteId");

                    b.HasIndex("NoParte");

                    b.HasIndex("ProduccionId");

                    b.ToTable("ProduccionNumerosParte");
                });

            modelBuilder.Entity("GpoSion.API.Models.Proveedor", b =>
                {
                    b.Property<int>("ProveedorId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Direccion");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefono");

                    b.Property<DateTime>("UltimaModificacion");

                    b.HasKey("ProveedorId");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("GpoSion.API.Models.Recibo", b =>
                {
                    b.Property<int>("ReciboId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CreadoPorId");

                    b.Property<string>("FacturaAduanal");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime?>("FechaEntrada");

                    b.Property<DateTime?>("HoraEntrada");

                    b.Property<bool>("IsComplete");

                    b.Property<string>("NoLote");

                    b.Property<int>("NoRecibo");

                    b.Property<string>("PedimentoImportacion");

                    b.Property<int?>("ProveedorId");

                    b.Property<string>("Recibio");

                    b.Property<string>("Transportista");

                    b.HasKey("ReciboId");

                    b.HasIndex("CreadoPorId");

                    b.HasIndex("ProveedorId");

                    b.ToTable("Recibos");
                });

            modelBuilder.Entity("GpoSion.API.Models.RequerimientoMaterial", b =>
                {
                    b.Property<int>("RequerimientoMaterialId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Almacenista");

                    b.Property<string>("Estatus");

                    b.Property<DateTime>("FechaSolicitud");

                    b.Property<DateTime?>("Fechaentrega");

                    b.Property<bool>("IsRead");

                    b.Property<string>("JefaLinea");

                    b.Property<string>("Recibio");

                    b.Property<int?>("TurnoId");

                    b.HasKey("RequerimientoMaterialId");

                    b.HasIndex("TurnoId");

                    b.ToTable("RequerimientosMaterial");
                });

            modelBuilder.Entity("GpoSion.API.Models.RequerimientoMaterialMaterial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<decimal>("CantidadEntregada")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<string>("Estatus");

                    b.Property<DateTime?>("FechaEntrega");

                    b.Property<int>("MaterialId");

                    b.Property<int>("RequerimientoMaterialId");

                    b.Property<int>("UnidadMedidaId");

                    b.Property<int?>("ViajeroId");

                    b.HasKey("Id");

                    b.HasIndex("MaterialId");

                    b.HasIndex("RequerimientoMaterialId");

                    b.HasIndex("UnidadMedidaId");

                    b.HasIndex("ViajeroId");

                    b.ToTable("RequerimientoMaterialMateriales");
                });

            modelBuilder.Entity("GpoSion.API.Models.TipoMaterial", b =>
                {
                    b.Property<int>("TipoMaterialId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Tipo");

                    b.HasKey("TipoMaterialId");

                    b.ToTable("TiposMaterial");
                });

            modelBuilder.Entity("GpoSion.API.Models.Turno", b =>
                {
                    b.Property<int>("TurnoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<int>("NoTurno");

                    b.HasKey("TurnoId");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("GpoSion.API.Models.UnidadMedida", b =>
                {
                    b.Property<int>("UnidadMedidaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descripcion");

                    b.Property<string>("Unidad");

                    b.HasKey("UnidadMedidaId");

                    b.ToTable("UnidadesMedida");
                });

            modelBuilder.Entity("GpoSion.API.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Activo");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<string>("Materno");

                    b.Property<string>("Nombre");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Paterno");

                    b.Property<DateTime>("UltimaModificacion");

                    b.Property<string>("Username")
                        .HasColumnName("Usuario");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GpoSion.API.Models.Viajero", b =>
                {
                    b.Property<int>("ViajeroId");

                    b.Property<decimal>("Existencia")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<DateTime>("Fecha");

                    b.Property<string>("Localidad");

                    b.Property<int>("MaterialId");

                    b.HasKey("ViajeroId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Viajeros");
                });

            modelBuilder.Entity("GpoSion.API.Models.DetalleRecibo", b =>
                {
                    b.HasOne("GpoSion.API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GpoSion.API.Models.Recibo", "Recibo")
                        .WithMany("Detalle")
                        .HasForeignKey("ReciboId");

                    b.HasOne("GpoSion.API.Models.UnidadMedida", "UnidadMedida")
                        .WithMany()
                        .HasForeignKey("UnidadMedidaId");

                    b.HasOne("GpoSion.API.Models.Viajero", "Viajero")
                        .WithMany()
                        .HasForeignKey("ViajeroId");
                });

            modelBuilder.Entity("GpoSion.API.Models.ExistenciaMaterial", b =>
                {
                    b.HasOne("GpoSion.API.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("GpoSion.API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");
                });

            modelBuilder.Entity("GpoSion.API.Models.Material", b =>
                {
                    b.HasOne("GpoSion.API.Models.TipoMaterial", "TipoMaterial")
                        .WithMany()
                        .HasForeignKey("TipoMaterialId");

                    b.HasOne("GpoSion.API.Models.UnidadMedida", "UnidadMedida")
                        .WithMany()
                        .HasForeignKey("UnidadMedidaId");
                });

            modelBuilder.Entity("GpoSion.API.Models.MaterialNumeroParte", b =>
                {
                    b.HasOne("GpoSion.API.Models.Material", "Material")
                        .WithMany("MaterialNumerosParte")
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GpoSion.API.Models.NumeroParte", "NumeroParte")
                        .WithMany("MaterialesNumeroParte")
                        .HasForeignKey("NoParte")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GpoSion.API.Models.Molde", b =>
                {
                    b.HasOne("GpoSion.API.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("GpoSion.API.Models.Usuario", "ModificadoPor")
                        .WithMany()
                        .HasForeignKey("ModificadoPorId");

                    b.HasOne("GpoSion.API.Models.Area", "Ubicacion")
                        .WithMany()
                        .HasForeignKey("UbicacionAreaId");
                });

            modelBuilder.Entity("GpoSion.API.Models.MoldeNumeroParte", b =>
                {
                    b.HasOne("GpoSion.API.Models.Molde", "Molde")
                        .WithMany("MoldeNumerosParte")
                        .HasForeignKey("MoldeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GpoSion.API.Models.NumeroParte", "NumeroParte")
                        .WithMany("MoldesNumeroParte")
                        .HasForeignKey("NoParte")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GpoSion.API.Models.Moldeadora", b =>
                {
                    b.HasOne("GpoSion.API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("GpoSion.API.Models.Molde", "Molde")
                        .WithMany()
                        .HasForeignKey("MoldeId");
                });

            modelBuilder.Entity("GpoSion.API.Models.MoldeadoraNumeroParte", b =>
                {
                    b.HasOne("GpoSion.API.Models.Moldeadora", "Moldeadora")
                        .WithMany("MoldeadoraNumerosParte")
                        .HasForeignKey("MoldeadoraId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GpoSion.API.Models.NumeroParte", "NumeroParte")
                        .WithMany("MoldeadorasNumeroParte")
                        .HasForeignKey("NoParte")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GpoSion.API.Models.MovimientoMaterial", b =>
                {
                    b.HasOne("GpoSion.API.Models.Area", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoAreaId");

                    b.HasOne("GpoSion.API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("GpoSion.API.Models.Usuario", "ModificadoPor")
                        .WithMany()
                        .HasForeignKey("ModificadoPorId");

                    b.HasOne("GpoSion.API.Models.Area", "Origen")
                        .WithMany()
                        .HasForeignKey("OrigenAreaId");

                    b.HasOne("GpoSion.API.Models.Recibo", "Recibo")
                        .WithMany()
                        .HasForeignKey("ReciboId");

                    b.HasOne("GpoSion.API.Models.RequerimientoMaterialMaterial", "RequerimientoMaterialMaterial")
                        .WithMany()
                        .HasForeignKey("RequerimientoMaterialMaterialId");

                    b.HasOne("GpoSion.API.Models.Viajero", "Viajero")
                        .WithMany("MovimientosMaterial")
                        .HasForeignKey("ViajeroId");
                });

            modelBuilder.Entity("GpoSion.API.Models.MovimientoMoldeadora", b =>
                {
                    b.HasOne("GpoSion.API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

                    b.HasOne("GpoSion.API.Models.Usuario", "ModificadoPor")
                        .WithMany()
                        .HasForeignKey("ModificadoPorId");

                    b.HasOne("GpoSion.API.Models.Molde", "Molde")
                        .WithMany()
                        .HasForeignKey("MoldeId");

                    b.HasOne("GpoSion.API.Models.Moldeadora", "Moldeadora")
                        .WithMany("MovimientosMoldeadora")
                        .HasForeignKey("MoldeadoraId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GpoSion.API.Models.MotivoTiempoMuerto", "MotivoTiempoMuerto")
                        .WithMany()
                        .HasForeignKey("MotivoTiempoMuertoId");
                });

            modelBuilder.Entity("GpoSion.API.Models.MovimientoMoldeadoraNumeroParte", b =>
                {
                    b.HasOne("GpoSion.API.Models.MovimientoMoldeadora", "MovimientoMoldeadora")
                        .WithMany("MovimientoMoldeadoraNumerosParte")
                        .HasForeignKey("MovimientoMoldeadoraId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("GpoSion.API.Models.NumeroParte", "NumeroParte")
                        .WithMany("MovimientosMoldeadoraNumeroParte")
                        .HasForeignKey("NoParte")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("GpoSion.API.Models.NumeroParte", b =>
                {
                    b.HasOne("GpoSion.API.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GpoSion.API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");
                });

            modelBuilder.Entity("GpoSion.API.Models.OrdenCompra", b =>
                {
                    b.HasOne("GpoSion.API.Models.Cliente", "Cliente")
                        .WithMany("OrdenesCompra")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GpoSion.API.Models.OrdenCompraDetalle", b =>
                {
                    b.HasOne("GpoSion.API.Models.OrdenCompra")
                        .WithMany("NumerosParte")
                        .HasForeignKey("NoOrden")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GpoSion.API.Models.NumeroParte", "NumeroParte")
                        .WithMany("OrdenesCompraDetalle")
                        .HasForeignKey("NoParte");
                });

            modelBuilder.Entity("GpoSion.API.Models.Produccion", b =>
                {
                    b.HasOne("GpoSion.API.Models.Moldeadora", "Moldeadora")
                        .WithMany()
                        .HasForeignKey("MoldeadoraId");
                });

            modelBuilder.Entity("GpoSion.API.Models.ProduccionNumeroParte", b =>
                {
                    b.HasOne("GpoSion.API.Models.NumeroParte", "NumeroParte")
                        .WithMany()
                        .HasForeignKey("NoParte");

                    b.HasOne("GpoSion.API.Models.Produccion", "Produccion")
                        .WithMany("ProduccionNumerosParte")
                        .HasForeignKey("ProduccionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GpoSion.API.Models.Recibo", b =>
                {
                    b.HasOne("GpoSion.API.Models.Usuario", "CreadoPor")
                        .WithMany()
                        .HasForeignKey("CreadoPorId");

                    b.HasOne("GpoSion.API.Models.Proveedor", "Proveedor")
                        .WithMany("Recibos")
                        .HasForeignKey("ProveedorId");
                });

            modelBuilder.Entity("GpoSion.API.Models.RequerimientoMaterial", b =>
                {
                    b.HasOne("GpoSion.API.Models.Turno", "Turno")
                        .WithMany()
                        .HasForeignKey("TurnoId");
                });

            modelBuilder.Entity("GpoSion.API.Models.RequerimientoMaterialMaterial", b =>
                {
                    b.HasOne("GpoSion.API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GpoSion.API.Models.RequerimientoMaterial", "Requerimiento")
                        .WithMany("Materiales")
                        .HasForeignKey("RequerimientoMaterialId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GpoSion.API.Models.UnidadMedida", "UnidadMedida")
                        .WithMany()
                        .HasForeignKey("UnidadMedidaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GpoSion.API.Models.Viajero", "Viajero")
                        .WithMany()
                        .HasForeignKey("ViajeroId");
                });

            modelBuilder.Entity("GpoSion.API.Models.Viajero", b =>
                {
                    b.HasOne("GpoSion.API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
