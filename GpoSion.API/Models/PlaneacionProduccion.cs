using System;
using System.ComponentModel.DataAnnotations;

namespace GpoSion.API.Models
{
    public class PlaneacionProduccion
    {
        [Key]
        public int año { get; set; }
        [Key]
        public int semana { get; set; }
        [Key]
        public string NoParte { get; set; }

        public virtual NumeroParte NumeroParte { get; set; }

        public int cantidad { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }
    }
}