using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class OrdenCompraDetalle
    {
        public int Id { get; set; }

        public NumeroParte NoParte { get; set; }
        public int NoOrden { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public Decimal Precio { get; set; }

        public int PiezasAutorizadas { get; set; }

        public int PiezasSurtidas { get; set; }

        public DateTime UltimaModificacion { get; set; }


    }
}