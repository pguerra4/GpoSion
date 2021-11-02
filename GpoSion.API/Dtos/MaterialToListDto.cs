using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MaterialtoListDto
    {
        public int MaterialId { get; set; }

        [JsonProperty("material")]
        public string ClaveMaterial { get; set; }

        public string Descripcion { get; set; }

        [JsonProperty("unidadMedidaId")]
        public int UnidadMedidaUnidadMedidaId { get; set; }

        [JsonProperty("unidadMedida")]
        public string UnidadMedidaUnidad { get; set; }

        public int TipoMaterialId { get; set; }

        [JsonProperty("tipoMaterial")]
        public string TipoMaterialTipo { get; set; }
        public int StockMinimo { get; set; }

    }
}