using System;
using System.Collections.Generic;

namespace GpoSion.API.Models
{
    public class Embarque
    {
        public int EmbarqueId { get; set; }
        public int Folio { get; set; }

        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string LENo { get; set; }

        public string Elaboro { get; set; }

        public string Recibio { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime UltimaModificacion { get; set; }

        public ICollection<DetalleEmbarque> Detallesembarque { get; set; }

    }
}