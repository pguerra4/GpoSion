using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MoldeForCreationDto
    {

        [JsonProperty("molde")]
        public string ClaveMolde { get; set; }

        public int ClienteId { get; set; }

        [JsonProperty("UbicacionId")]
        public int UbicacionAreaId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public MoldeForCreationDto()
        {
            FechaCreacion = DateTime.Now;
        }

    }
}