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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<UnidadMedida>()
            //     .HasAlternateKey(u => u.Unidad)
            //     .HasName("AlternateKey_Unidad");

            // modelBuilder.Entity<Viajero>().HasKey(v => v.ViajeroId);
        }

    }
}