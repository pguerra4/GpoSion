using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MoldeToListDto
    {



        public int Id { get; set; }

        [JsonProperty("molde")]
        public string ClaveMolde { get; set; }

        [JsonProperty("cliente")]
        public string ClienteNombre { get; set; }

        [JsonProperty("ubicacion")]
        public string UbicacionNombreArea { get; set; }

        [JsonProperty("moldeadora")]
        public String MoldeadoraClave { get; set; }

        public int? EstatusMoldeId { get; set; }

        [JsonProperty("estatusMolde")]
        public string EstatusEstatus { get; set; }

        public DateTime? UltimaModificacion { get; set; }

    }
}