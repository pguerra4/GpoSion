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

        [ForeignKey("ViajeroId")]
        public virtual Viajero Viajero { get; set; }
        public string ReferenciaCliente { get; set; }

        public string NoLote { get; set; }

        public int? ReciboId { get; set; }

        [ForeignKey("ReciboId")]
        public virtual Recibo Recibo { get; set; }

        public int MaterialId { get; set; }


        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }

        public int? UnidadMedidaId { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public virtual UnidadMedida UnidadMedida { get; set; }

        public int? LocalidadId { get; set; }

        [ForeignKey("LocalidadId")]
        public virtual Localidad Localidad { get; set; }

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