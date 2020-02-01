using System;

namespace GpoSion.API.Models
{
    public class Turno
    {
        public int TurnoId { get; set; }
        public int NoTurno { get; set; }
        public string Descripcion { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


    }
}