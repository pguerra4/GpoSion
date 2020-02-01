using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class DetalleRecibo
    {
        public int DetalleReciboId { get; set; }

        public int TotalCajas { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public Decimal CantidadPorCaja { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public Decimal Total { get; set; }
        public string Referencia2 { get; set; }
        public int? ViajeroId { get; set; }

        public virtual Viajero Viajero { get; set; }
        public string ReferenciaCliente { get; set; }

        public string NoLote { get; set; }

        public virtual Recibo Recibo { get; set; }

        public int MaterialId { get; set; }

        public virtual Material Material { get; set; }

        public virtual UnidadMedida UnidadMedida { get; set; }

        public int? LocalidadId { get; set; }
        public virtual Localidad Localidad { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


    }
}