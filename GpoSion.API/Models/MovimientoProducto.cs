using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MovimientoProducto
    {
        public int MovimientoProductoId { get; set; }

        public string NoParte { get; set; }

        public NumeroParte NumeroParte { get; set; }

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

        public string Localidad { get; set; }

        public int? DetalleEmbarqueId { get; set; }
        public DetalleEmbarque DetalleEmbarque { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }

    }
}