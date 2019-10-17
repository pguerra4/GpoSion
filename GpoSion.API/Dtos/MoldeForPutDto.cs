using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MoldeForPutDto
    {
        public int Id { get; set; }

        [JsonProperty("molde")]
        public string ClaveMolde { get; set; }

        public int ClienteId { get; set; }

        [JsonProperty("ubicacionId")]
        public int UbicacionAreaId { get; set; }

        [JsonProperty("moldeadoraId")]
        public int? MaquinaMoldeadoraId { get; set; }

        public DateTime UltimaModificacion { get; set; }

        public MoldeForPutDto()
        {
            UltimaModificacion = DateTime.Now;
        }

    }
}