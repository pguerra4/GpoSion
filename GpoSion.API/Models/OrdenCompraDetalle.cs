using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class OrdenCompraDetalle
    {
        public int Id { get; set; }

        public string NoParte { get; set; }
        public NumeroParte NumeroParte { get; set; }
        public long NoOrden { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public Decimal Precio { get; set; }

        public int PiezasAutorizadas { get; set; }

        public int PiezasSurtidas { get; set; }

        public DateTime UltimaModificacion { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }


    }
}