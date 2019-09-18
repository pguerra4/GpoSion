﻿// <auto-generated />
using System;
using GpoSion.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GpoSion.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190918002553_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GpoSion.API.Models.Area", b =>
                {
                    b.Property<int>("AreaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura");

                    b.Property<string>("NombreArea")
                        .HasColumnName("Area");

                    b.HasKey("AreaId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("GpoSion.API.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave");

                    b.Property<string>("Direccion");

                    b.Property<DateTime>("FechaCreacion");

                    b.Property<string>("Nombre")
                        .HasColumnName("Cliente");

                    b.Property<DateTime>("UltimaModificacion");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GpoSion.API.Models.ExistenciaMaterial", b =>
                {
                    b.Property<int>("ExistenciaMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaId");

                    b.Property<decimal>("Existencia")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int?>("MaterialId");

                    b.HasKey("ExistenciaMaterialId");

                    b.HasIndex("AreaId");

                    b.HasIndex("MaterialId");

                    b.ToTable("ExistenciasMaterial");
                });

            modelBuilder.Entity("GpoSion.API.Models.Material", b =>
                {
                    b.Property<int>("MaterialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clave");

                    b.HasKey("MoldeadoraId");

                    b.ToTable("Moldeadoras");
                });

            modelBuilder.Entity("GpoSion.API.Models.MovimientoMaterial", b =>
                {
                    b.Property<int>("MovimientoMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cantidad")
                        .HasColumnType("decimal(18, 3)");

                    b.Property<int?>("DestinoAreaId");

                    b.Property<DateTime>("Fecha");

                    b.Property<int?>("MaterialId");

                    b.Property<int?>("ModificadoPorId");

                    b.Property<int?>("OrigenAreaId");

                    b.HasKey("MovimientoMaterialId");

                    b.HasIndex("DestinoAreaId");

                    b.HasIndex("MaterialId");

                    b.HasIndex("ModificadoPorId");

                    b.HasIndex("OrigenAreaId");

                    b.ToTable("MovimientosMaterial");
                });

            modelBuilder.Entity("GpoSion.API.Models.TipoMaterial", b =>
                {
                    b.Property<int>("TipoMaterialId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo");

                    b.HasKey("TipoMaterialId");

                    b.ToTable("TiposMaterial");
                });

            modelBuilder.Entity("GpoSion.API.Models.UnidadMedida", b =>
                {
                    b.Property<int>("UnidadMedidaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<string>("Unidad");

                    b.HasKey("UnidadMedidaId");

                    b.ToTable("UnidadesMedida");
                });

            modelBuilder.Entity("GpoSion.API.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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
                });
#pragma warning restore 612, 618
        }
    }
}
