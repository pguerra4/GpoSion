using System;

namespace GpoSion.API.Models
{
    public class HistorialOrdenCompra
    {
        public int HistorialOrdenCompraId { get; set; }
        public string Observaciones { get; set; }

        public long NoOrden { get; set; }

        public virtual OrdenCompra OrdenCompra { get; set; }


        public int? OrdenCompraDetalleId { get; set; }
        public virtual OrdenCompraDetalle DetalleOrdenCompra { get; set; }

        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public DateTime Fecha { get; set; }

    }
}