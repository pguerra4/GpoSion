using System;

namespace GpoSion.API.Models
{
    public class HistorialOrdenCompra
    {
        public int HistorialOrdenCompraId { get; set; }
        public string Observaciones { get; set; }

        public long NoOrden { get; set; }

        public OrdenCompra OrdenCompra { get; set; }

        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public DateTime Fecha { get; set; }

    }
}