using System;

namespace GpoSion.API.Helpers
{
    public class EmbarqueParams
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public int? ClienteId { get; set; }
    }
}