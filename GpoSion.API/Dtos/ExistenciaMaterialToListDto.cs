using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class ExistenciaMaterialToListDto
    {
        public int ExistenciaMaterialId { get; set; }

        [JsonProperty(PropertyName = "materialId")]
        public int MaterialMaterialId { get; set; }

        [JsonProperty(PropertyName = "material")]
        public string MaterialClaveMaterial { get; set; }

        [JsonProperty(PropertyName = "areaId")]
        public int AreaAreaId { get; set; }

        [JsonProperty(PropertyName = "area")]
        public string AreaNombreArea { get; set; }

        public decimal Existencia { get; set; }

        public string UnidadMedida { get; set; }

        public DateTime UltimaModificacion { get; set; }

        public string[] NumerosParte { get; set; }

        

    }
}