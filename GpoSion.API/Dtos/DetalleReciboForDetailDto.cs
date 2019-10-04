using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class DetalleReciboForDetailDto
    {


        public int? TotalCajas { get; set; }

        public Decimal? CantidadPorCaja { get; set; }

        public Decimal Total { get; set; }

        public string Referencia2 { get; set; }

        [JsonProperty(PropertyName = "viajero")]
        public int ViajeroId { get; set; }
        public string ReferenciaCliente { get; set; }

        [JsonProperty(PropertyName = "reciboId")]
        public int ReciboReciboId { get; set; }
        public string ReciboNoRecibo { get; set; }

        [JsonProperty(PropertyName = "materialId")]
        public int MaterialMaterialId { get; set; }
        public string Material { get; set; }

        public int UnidadMedidaId { get; set; }
        public string Unidad { get; set; }
    }
}