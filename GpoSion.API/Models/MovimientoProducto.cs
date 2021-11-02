using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MovimientoProducto
    {
        public int MovimientoProductoId { get; set; }

        public string NoParte { get; set; }

        [ForeignKey("NoParte")]
        public virtual NumeroParte NumeroParte { get; set; }

        public DateTime Fecha { get; set; }

        public int Cajas { get; set; }

        public int PiezasXCaja { get; set; }

        public int PiezasCertificadas { get; set; }

        public int PiezasRechazadas { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Purga { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Colada { get; set; }

        public string TipoMovimiento { get; set; }


        public int? ExistenciaAlmacenInicial { get; set; }


        public int? ExistenciaAlmacenFinal { get; set; }

        public int? LocalidadId { get; set; }

        [ForeignKey("LocalidadId")]
        public virtual Localidad Localidad { get; set; }

        public int? DetalleEmbarqueId { get; set; }

        [ForeignKey("DetalleEmbarqueId")]
        public virtual DetalleEmbarque DetalleEmbarque { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }

        [ForeignKey("ModificadoPorId")]
        public virtual User ModificadoPor { get; set; }

    }
}