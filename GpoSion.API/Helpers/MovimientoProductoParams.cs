using System;

namespace GpoSion.API.Helpers
{
    public class MovimientoProductoParams
    {
        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }
        public string TipoMovimiento { get; set; }

    }
}