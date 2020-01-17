using System;

namespace GpoSion.API.Models
{
    public class DetalleEmbarque
    {
        public int DetalleEmbarqueId { get; set; }

        public int EmbarqueId { get; set; }
        public Embarque Embarque { get; set; }

        public string NoParte { get; set; }
        public NumeroParte NumeroParte { get; set; }

        public long? NoOrden { get; set; }
        public OrdenCompra OrdenCompra { get; set; }

        public int Cajas { get; set; }
        public int PiezasXCaja { get; set; }

        public int Entregadas { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }


    }
}