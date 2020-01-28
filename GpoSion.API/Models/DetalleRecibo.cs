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

        public Viajero Viajero { get; set; }
        public string ReferenciaCliente { get; set; }

        public string NoLote { get; set; }

        public Recibo Recibo { get; set; }

        public int MaterialId { get; set; }

        public Material Material { get; set; }

        public UnidadMedida UnidadMedida { get; set; }

        public int? LocalidadId { get; set; }
        public Localidad Localidad { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }


    }
}