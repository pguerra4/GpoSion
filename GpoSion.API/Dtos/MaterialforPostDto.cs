
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MaterialforPostDto
    {

        [JsonProperty("material")]
        public string ClaveMaterial { get; set; }

        public string Descripcion { get; set; }

        public int UnidadMedidaId { get; set; }

        public int TipoMaterialId { get; set; }

        public int StockMinimo { get; set; }

    }
}