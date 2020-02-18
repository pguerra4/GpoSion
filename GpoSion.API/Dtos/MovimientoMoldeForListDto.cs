using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MovimientoMoldeForListDto
    {
        public int MovimientoMoldeId { get; set; }

        public int MoldeId { get; set; }

        [JsonProperty(PropertyName = "molde")]
        public string MoldeClaveMolde { get; set; }

        public DateTime Fecha { get; set; }

        public int EstatusMoldeId { get; set; }

        [JsonProperty(PropertyName = "estatusMolde")]
        public string EstatusEstatus { get; set; }

        public string Observaciones { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public string CreadoPorId { get; set; }

        [JsonProperty(PropertyName = "creadoPor")]
        public string CreadoPorUserName { get; set; }


    }
}