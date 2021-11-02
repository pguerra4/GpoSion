using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class ViajeroToListDto
    {

        [JsonProperty("viajero")]
        public int ViajeroId { get; set; }


        public int MaterialId { get; set; }

        [JsonProperty("material")]
        public string MaterialClaveMaterial { get; set; }

        public decimal Existencia { get; set; }

        public int? LocalidadId { get; set; }

        [JsonProperty("localidad")]
        public string LocalizacionDescripcion { get; set; }
        public DateTime Fecha { get; set; }


    }
}