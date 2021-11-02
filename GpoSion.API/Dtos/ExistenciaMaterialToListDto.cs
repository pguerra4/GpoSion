using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class ExistenciaMaterialToListDto
    {
        public int ExistenciaMaterialId { get; set; }

        [JsonProperty("materialId")]
        public int MaterialMaterialId { get; set; }

        [JsonProperty("material")]
        public string MaterialClaveMaterial { get; set; }

        [JsonProperty("areaId")]
        public int AreaAreaId { get; set; }

        [JsonProperty("area")]
        public string AreaNombreArea { get; set; }

        public decimal Existencia { get; set; }

        public string UnidadMedida { get; set; }

        public DateTime UltimaModificacion { get; set; }

        public string[] NumerosParte { get; set; }

    }
}