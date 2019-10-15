using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class DetalleReciboForDetailDto
    {

        public int DetalleReciboId { get; set; }
        public int? TotalCajas { get; set; }

        public Decimal? CantidadPorCaja { get; set; }

        public Decimal Total { get; set; }

        public string Referencia2 { get; set; }

        [JsonProperty(PropertyName = "viajero")]
        public int ViajeroId { get; set; }
        public string ReferenciaCliente { get; set; }

        [JsonProperty(PropertyName = "reciboId")]
        public int ReciboReciboId { get; set; }

        [JsonProperty(PropertyName = "noRecibo")]
        public string ReciboNoRecibo { get; set; }

        [JsonProperty(PropertyName = "materialId")]
        public int MaterialMaterialId { get; set; }
        public string Material { get; set; }

        [JsonProperty(PropertyName = "unidadMedidaId")]
        public int UnidadMedidaUnidadMedidaId { get; set; }
        public string Unidad { get; set; }

        public string Localidad { get; set; }

    }
}