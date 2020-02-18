using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MoldeToListDto
    {



        public int Id { get; set; }

        [JsonProperty("molde")]
        public string ClaveMolde { get; set; }

        [JsonProperty(PropertyName = "cliente")]
        public string ClienteNombre { get; set; }

        [JsonProperty(PropertyName = "ubicacion")]
        public string UbicacionNombreArea { get; set; }

        [JsonProperty(PropertyName = "moldeadora")]
        public String MoldeadoraClave { get; set; }

        public int? EstatusMoldeId { get; set; }

        [JsonProperty(PropertyName = "estatusMolde")]
        public string EstatusEstatus { get; set; }



    }
}