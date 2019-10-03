using System;

namespace GpoSion.API.Dtos
{
    public class ReciboToListDto
    {
        public int ReciboId { get; set; }
        public int NoRecibo { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? HoraEntrada { get; set; }


        public string Transportista { get; set; }

        public string Recibio { get; set; }

        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; }

    }
}