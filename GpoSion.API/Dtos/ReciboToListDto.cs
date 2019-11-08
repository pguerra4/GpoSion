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


        public bool IsComplete { get; set; }

        public string NoLote { get; set; }

        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; }



    }
}