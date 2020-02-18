using System;

namespace GpoSion.API.Models
{
    public class MovimientoMolde
    {
        public int MovimientoMoldeId { get; set; }

        public int MoldeId { get; set; }
        public virtual Molde Molde { get; set; }
        public DateTime Fecha { get; set; }

        public int EstatusMoldeId { get; set; }

        public virtual EstatusMolde Estatus { get; set; }

        public string Observaciones { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

    }
}