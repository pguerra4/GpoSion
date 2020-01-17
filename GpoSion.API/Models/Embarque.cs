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

        public bool Rechazadas { get; set; } = false;

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }


        public ICollection<DetalleEmbarque> DetallesEmbarque { get; set; }

    }
}