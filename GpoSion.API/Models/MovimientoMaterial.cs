using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MovimientoMaterial
    {
        public int MovimientoMaterialId { get; set; }
        public DateTime Fecha { get; set; }

        public int? MaterialId { get; set; }
        public virtual Material Material { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Cantidad { get; set; }

        public virtual Area Origen { get; set; }
        public virtual Area Destino { get; set; }

        public string MotivoMovimiento { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


        public virtual Recibo Recibo { get; set; }

        public int? ViajeroId { get; set; }

        public virtual Viajero Viajero { get; set; }

        public int? LocalidadId { get; set; }

        public virtual Localidad Localidad { get; set; }

         [Column(TypeName = "decimal(18, 3)")]
        public decimal? ExistenciaInicial { get; set; }

         [Column(TypeName = "decimal(18, 3)")]
        public decimal? ExistenciaFinal { get; set; }

        public int? RequerimientoMaterialMaterialId { get; set; }
        public virtual RequerimientoMaterialMaterial RequerimientoMaterialMaterial { get; set; }

    }
}