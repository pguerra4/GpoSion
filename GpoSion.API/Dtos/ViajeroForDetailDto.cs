using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class ViajeroForDetailDto
    {

        [JsonProperty(PropertyName = "viajero")]
        public int ViajeroId { get; set; }


        public int MaterialId { get; set; }

        [JsonProperty(PropertyName = "material")]
        public string MaterialClaveMaterial { get; set; }

        public decimal Existencia { get; set; }

        public string Localidad { get; set; }
        public DateTime Fecha { get; set; }

        public ICollection<MovimientoMaterialForViajeroDetailDto> MovimientosMaterial { get; set; }

    }
}