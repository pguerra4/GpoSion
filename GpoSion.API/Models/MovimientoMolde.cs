using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MovimientoMolde
    {
        public int MovimientoMoldeId { get; set; }

        public int MoldeId { get; set; }

        [ForeignKey("MoldeId")]
        public virtual Molde Molde { get; set; }
        public DateTime Fecha { get; set; }

        public int EstatusMoldeId { get; set; }

        [ForeignKey("EstatusMoldeId")]
        public virtual EstatusMolde Estatus { get; set; }

        public string Observaciones { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public virtual User CreadoPor { get; set; }

    }
}