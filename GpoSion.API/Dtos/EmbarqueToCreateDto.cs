using System;
using System.Collections.Generic;

namespace GpoSion.API.Dtos
{
    public class EmbarqueToCreateDto
    {

        public int Folio { get; set; }

        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }

        public string LENo { get; set; }

        public string Elaboro { get; set; }

        public string Recibio { get; set; }

        public DateTime FechaCreacion { get; set; }

        public bool Rechazadas { get; set; }

        public ICollection<DetalleEmbarqueToCreateDto> DetallesEmbarque { get; set; }

        public EmbarqueToCreateDto()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}