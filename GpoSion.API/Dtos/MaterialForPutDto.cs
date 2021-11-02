
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MaterialForPutDto
    {
        public int MaterialId { get; set; }

        [JsonProperty("material")]
        public string ClaveMaterial { get; set; }

        public string Descripcion { get; set; }

        public int UnidadMedidaId { get; set; }

        public int TipoMaterialId { get; set; }

        public decimal Cantidad { get; set; }

        public int StockMinimo { get; set; }

    }
}