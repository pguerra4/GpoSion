using System;

namespace GpoSion.API.Models
{
    public class ExistenciaProducto
    {
        public int ExistenciaProductoId { get; set; }

        public string NoParte { get; set; }
        public virtual NumeroParte NumeroParte { get; set; }

        public int PiezasCertificadas { get; set; }
        public int PiezasRechazadas { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


    }
}