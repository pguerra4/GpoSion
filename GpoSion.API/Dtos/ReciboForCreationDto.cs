using System;

namespace GpoSion.API.Dtos
{
    public class ReciboForCreationDto
    {

        public int NoRecibo { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? HoraEntrada { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Transportista { get; set; }
        public string FacturaAduanal { get; set; }
        public string PedimentoImportacion { get; set; }

        public string Recibio { get; set; }

        public int ClienteId { get; set; }

        public int? CreadoPorId { get; set; }


        public ReciboForCreationDto()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}