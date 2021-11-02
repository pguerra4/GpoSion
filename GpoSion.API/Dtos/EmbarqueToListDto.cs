using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class EmbarqueToListDto
    {

        public int EmbarqueId { get; set; }
        public int Folio { get; set; }

        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }

        [JsonProperty("cliente")]
        public string ClienteNombre { get; set; }

        public string LENo { get; set; }

        public string Elaboro { get; set; }

        public string Recibio { get; set; }

        public bool Rechazadas { get; set; }


        public ICollection<DetalleEmbarqueToListDto> DetallesEmbarque { get; set; }


    }
}