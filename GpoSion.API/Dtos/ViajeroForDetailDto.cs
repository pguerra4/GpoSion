using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class ViajeroForDetailDto
    {

        [JsonProperty("viajero")]
        public int ViajeroId { get; set; }


        public int MaterialId { get; set; }

        [JsonProperty("material")]
        public string MaterialClaveMaterial { get; set; }

        public decimal Existencia { get; set; }

        public decimal ExistenciaProduccion { get; set; }

        public int? LocalidadId { get; set; }

        [JsonProperty("localidad")]
        public string LocalizacionDescripcion { get; set; }

        public DateTime Fecha { get; set; }

        public ICollection<MovimientoMaterialForViajeroDetailDto> MovimientosMaterial { get; set; }

    }
}