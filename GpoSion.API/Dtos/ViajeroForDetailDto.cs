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

        public decimal ExistenciaProduccion { get; set; }

        public int? LocalidadId { get; set; }

        [JsonProperty(PropertyName = "localidad")]
        public string LocalizacionDescripcion { get; set; }

        public DateTime Fecha { get; set; }

        public ICollection<MovimientoMaterialForViajeroDetailDto> MovimientosMaterial { get; set; }

    }
}