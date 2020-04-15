using System;

namespace GpoSion.API.Models
{
    public class Mensaje
    {
        public int MensajeId { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }

        public string URL { get; set; }

        public DateTime FechaEnvio { get; set; }
        public DateTime? FechaLectura { get; set; }

        public string Estatus { get; set; }

        public string ReceptorId { get; set; }
        public virtual User Receptor { get; set; }

        public string EmisorId { get; set; }
        public virtual User Emisor { get; set; }

        public string Grupo { get; set; }

    }
}