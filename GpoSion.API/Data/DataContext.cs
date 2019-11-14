using GpoSion.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GpoSion.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<Molde> Moldes { get; set; }
        public DbSet<Moldeadora> Moldeadoras { get; set; }
        public DbSet<TipoMaterial> TiposMaterial { get; set; }
        public DbSet<UnidadMedida> UnidadesMedida { get; set; }
        public DbSet<MovimientoMaterial> MovimientosMaterial { get; set; }
        public DbSet<ExistenciaMaterial> ExistenciasMaterial { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Recibo> Recibos { get; set; }

        public DbSet<DetalleRecibo> DetalleRecibos { get; set; }

        public DbSet<Viajero> Viajeros { get; set; }

        public DbSet<RequerimientoMaterial> RequerimientosMaterial { get; set; }

        public DbSet<RequerimientoMaterialMaterial> RequerimientoMaterialMateriales { get; set; }

        public DbSet<Turno> Turnos { get; set; }

        public DbSet<OrdenCompra> OrdenesCompra { get; set; }

        public DbSet<OrdenCompraDetalle> OrdenCompraDetalles { get; set; }

        public DbSet<NumeroParte> NumerosParte { get; set; }


        public DbSet<MoldeadoraNumeroParte> MoldeadoraNumerosParte { get; set; }

        public DbSet<MoldeNumeroParte> MoldeNumerosParte { get; set; }

        public DbSet<MovimientoMoldeadora> MovimientosMoldeadora { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<MaterialNumeroParte> MaterialesNumerosParte { get; set; }

        public DbSet<Produccion> Produccion { get; set; }

        public DbSet<ProduccionNumeroParte> ProduccionNumerosParte { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<UnidadMedida>()
            //     .HasAlternateKey(u => u.Unidad)
            //     .HasName("AlternateKey_Unidad");

            // modelBuilder.Entity<Viajero>().HasKey(v => v.ViajeroId);

            modelBuilder.Entity<MoldeadoraNumeroParte>().HasKey(mn => new { mn.MoldeadoraId, mn.NoParte });
            modelBuilder.Entity<MoldeadoraNumeroParte>().HasOne(mn => mn.Moldeadora).WithMany(m => m.MoldeadoraNumerosParte).HasForeignKey(mn => mn.MoldeadoraId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MoldeadoraNumeroParte>().HasOne(mn => mn.NumeroParte).WithMany(n => n.MoldeadorasNumeroParte).HasForeignKey(mn => mn.NoParte).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MoldeNumeroParte>().HasKey(mn => new { mn.MoldeId, mn.NoParte });
            modelBuilder.Entity<MoldeNumeroParte>().HasOne(mn => mn.Molde).WithMany(m => m.MoldeNumerosParte).HasForeignKey(mn => mn.MoldeId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MoldeNumeroParte>().HasOne(mn => mn.NumeroParte).WithMany(n => n.MoldesNumeroParte).HasForeignKey(mn => mn.NoParte).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MaterialNumeroParte>().HasKey(mn => new { mn.MaterialId, mn.NoParte });
            modelBuilder.Entity<MaterialNumeroParte>().HasOne(mn => mn.Material).WithMany(m => m.MaterialNumerosParte).HasForeignKey(mn => mn.MaterialId).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<MaterialNumeroParte>().HasOne(mn => mn.NumeroParte).WithMany(n => n.MaterialesNumeroParte).HasForeignKey(mn => mn.NoParte).OnDelete(DeleteBehavior.Restrict);

        }

    }
}