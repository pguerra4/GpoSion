using System;

namespace GpoSion.API.Models
{
    public class ExistenciaProducto
    {
        public int ExistenciaProductoId { get; set; }

        public string NoParte { get; set; }
        public NumeroParte NumeroParte { get; set; }

        public int PiezasCertificadas { get; set; }
        public int PiezasRechazadas { get; set; }

        public DateTime UltimaModificacion { get; set; }

    }
}