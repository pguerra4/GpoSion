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

        public int PiezasCaja { get; set; }

        public int PiezasCertificadas { get; set; }

        public int PiezasRechazadas { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Purga { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Colada { get; set; }

        public string TipoMovimiento { get; set; }

        public bool Embarcadas { get; set; }

        public int OrdenCompraId { get; set; }

        public string Localidad { get; set; }
    }
}