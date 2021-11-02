using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class LocalidadNumeroParteToListDto
    {
        public int LocalidadId { get; set; }

        [JsonProperty("localidad")]
        public string LocalidadDescripcion { get; set; }

        public string NoParte { get; set; }

        public decimal Existencia { get; set; }

        public decimal Rechazadas { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }

        [JsonProperty("creadoPor")]
        public string CreadoPorUserName { get; set; }

        public string ModificadoPorId { get; set; }

        [JsonProperty("modificadoPor")]
        public string ModificadoPorUserName { get; set; }
    }
}