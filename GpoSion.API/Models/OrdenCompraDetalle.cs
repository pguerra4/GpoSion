using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class OrdenCompraDetalle
    {
        public int Id { get; set; }

        public string NoParte { get; set; }
        public virtual NumeroParte NumeroParte { get; set; }
        public long NoOrden { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public Decimal Precio { get; set; }

        public int PiezasAutorizadas { get; set; }

        public int PiezasSurtidas { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public virtual ICollection<HistorialOrdenCompra> Historial { get; set; }

    }
}