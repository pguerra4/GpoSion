using System;

namespace GpoSion.API.Helpers
{
    public class ReporteParams
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public int? ClienteId { get; set; }

        public string NoParte { get; set; }

        public int? MaterialId { get; set; }
    }
}