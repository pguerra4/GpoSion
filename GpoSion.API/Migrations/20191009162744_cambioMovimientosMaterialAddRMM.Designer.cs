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
    [Migration("20191009162744_cambioMovimientosMaterialAddRMM")]
    partial class cambioMovimientosMaterialAddRMM
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

                    b.Property<int?>("MaterialId");

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

                    b.Property<int?>("ClienteId");

                    b.Property<string>("Descripcion");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<int?>("TipoMaterialId");

                    b.Property<DateTime>("UltimaModificacion");

                    b.Property<int?>("UnidadMedidaId");

                    b.HasKey("MaterialId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("TipoMaterialId");

                    b.HasIndex("UnidadMedidaId");

                    b.ToTable("Materiales");
                });

            modelBuilder.Entity("GpoSion.API.Models.Molde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaveMolde")
                        .HasColumnName("Molde");

                    b.Property<int?>("ClienteId");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<int?>("MaquinaMoldeadoraId");

                    b.Property<int?>("ModificadoPorId");

                    b.Property<int?>("UbicacionAreaId");

                    b.Property<DateTime>("UltimaModificacion");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("MaquinaMoldeadoraId");

                    b.HasIndex("ModificadoPorId");

                    b.HasIndex("UbicacionAreaId");

                    b.ToTable("Moldes");
                });

            modelBuilder.Entity("GpoSion.API.Models.Moldeadora", b =>
                {
                    b.Property<int>("MoldeadoraId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Clave");

                    b.HasKey("MoldeadoraId");

                    b.ToTable("Moldeadoras");
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

            modelBuilder.Entity("GpoSion.API.Models.Recibo", b =>
                {
                    b.Property<int>("ReciboId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClienteId");

                    b.Property<int?>("CreadoPorId");

                    b.Property<string>("FacturaAduanal");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<DateTime?>("FechaEntrada");

                    b.Property<DateTime?>("HoraEntrada");

                    b.Property<bool>("IsComplete");

                    b.Property<int>("NoRecibo");

                    b.Property<string>("PedimentoImportacion");

                    b.Property<string>("Recibio");

                    b.Property<string>("Transportista");

                    b.HasKey("ReciboId");

                    b.HasIndex("ClienteId");

                    b.HasIndex("CreadoPorId");

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

                    b.Property<int>("MaterialId");

                    b.HasKey("ViajeroId");

                    b.HasIndex("MaterialId");

                    b.ToTable("Viajeros");
                });

            modelBuilder.Entity("GpoSion.API.Models.DetalleRecibo", b =>
                {
                    b.HasOne("GpoSion.API.Models.Material", "Material")
                        .WithMany()
                        .HasForeignKey("MaterialId");

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
                    b.HasOne("GpoSion.API.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("GpoSion.API.Models.TipoMaterial", "TipoMaterial")
                        .WithMany()
                        .HasForeignKey("TipoMaterialId");

                    b.HasOne("GpoSion.API.Models.UnidadMedida", "UnidadMedida")
                        .WithMany()
                        .HasForeignKey("UnidadMedidaId");
                });

            modelBuilder.Entity("GpoSion.API.Models.Molde", b =>
                {
                    b.HasOne("GpoSion.API.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("GpoSion.API.Models.Moldeadora", "Maquina")
                        .WithMany()
                        .HasForeignKey("MaquinaMoldeadoraId");

                    b.HasOne("GpoSion.API.Models.Usuario", "ModificadoPor")
                        .WithMany()
                        .HasForeignKey("ModificadoPorId");

                    b.HasOne("GpoSion.API.Models.Area", "Ubicacion")
                        .WithMany()
                        .HasForeignKey("UbicacionAreaId");
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

            modelBuilder.Entity("GpoSion.API.Models.Recibo", b =>
                {
                    b.HasOne("GpoSion.API.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("GpoSion.API.Models.Usuario", "CreadoPor")
                        .WithMany()
                        .HasForeignKey("CreadoPorId");
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
