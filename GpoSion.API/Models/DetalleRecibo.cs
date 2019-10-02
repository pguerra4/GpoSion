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
        public int Viajero { get; set; }
        public string ReferenciaCliente { get; set; }

        public Recibo Recibo { get; set; }

        public Material Material { get; set; }

        public UnidadMedida UnidadMedida { get; set; }



    }
}