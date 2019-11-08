using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MaterialtoListDto
    {
        public int MaterialId { get; set; }

        [JsonProperty(PropertyName = "material")]
        public string ClaveMaterial { get; set; }

        public string Descripcion { get; set; }

        public int UnidadMedidaId { get; set; }

        [JsonProperty(PropertyName = "unidadMedida")]
        public string UnidadMedidaUnidad { get; set; }

        public int TipoMaterialId { get; set; }

        [JsonProperty(PropertyName = "tipoMaterial")]
        public string TipoMaterialTipo { get; set; }

    }
}