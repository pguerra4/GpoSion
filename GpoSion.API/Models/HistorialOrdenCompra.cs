using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class HistorialOrdenCompra
    {
        public int HistorialOrdenCompraId { get; set; }
        public string Observaciones { get; set; }

        public long NoOrden { get; set; }

        [ForeignKey("NoOrden")]
        public virtual OrdenCompra OrdenCompra { get; set; }


        public int? OrdenCompraDetalleId { get; set; }

        [ForeignKey("OrdenCompraDetalleId")]
        public virtual OrdenCompraDetalle DetalleOrdenCompra { get; set; }

        public string CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public virtual User CreadoPor { get; set; }

        public DateTime Fecha { get; set; }

    }
}