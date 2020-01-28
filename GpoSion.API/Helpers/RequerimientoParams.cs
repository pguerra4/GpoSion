using System;

namespace GpoSion.API.Helpers
{
    public class RequerimientoParams
    {
        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public bool? MostrarSurtidos { get; set; }
    }
}