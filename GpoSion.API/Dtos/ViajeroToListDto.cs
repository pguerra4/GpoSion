using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class ViajeroToListDto
    {

        [JsonProperty(PropertyName = "viajero")]
        public int ViajeroId { get; set; }


        public int MaterialId { get; set; }

        [JsonProperty(PropertyName = "material")]
        public string MaterialClaveMaterial { get; set; }

        public decimal Existencia { get; set; }

        public int? LocalidadId { get; set; }

        [JsonProperty(PropertyName = "localidad")]
        public string LocalizacionDescripcion { get; set; }
        public DateTime Fecha { get; set; }


    }
}