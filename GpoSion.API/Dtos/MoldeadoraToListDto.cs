using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MoldeadoraToListDto
    {
        public int MoldeadoraId { get; set; }

        [JsonProperty("moldeadora")]
        public string Clave { get; set; }

        public string Estatus { get; set; }

        public decimal? DisparosPorHora { get; set; }

        public int? MoldeId { get; set; }
        [JsonProperty("molde")]
        public string MoldeClaveMolde { get; set; }

        public int? MaterialId { get; set; }
        [JsonProperty("material")]
        public string MaterialClaveMaterial { get; set; }

        public DateTime? UltimaModificacion { get; set; }

        public int? UltimoMotivoParo { get; set; }

        public ICollection<string> NumerosParte { get; set; }
    }
}