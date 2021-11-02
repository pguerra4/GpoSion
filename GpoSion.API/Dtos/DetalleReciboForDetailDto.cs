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

        [JsonProperty("viajero")]
        public int ViajeroId { get; set; }
        public string ReferenciaCliente { get; set; }
        public string NoLote { get; set; }

        [JsonProperty("reciboId")]
        public int ReciboReciboId { get; set; }

        [JsonProperty("noRecibo")]
        public string ReciboNoRecibo { get; set; }

        [JsonProperty("materialId")]
        public int MaterialMaterialId { get; set; }
        public string Material { get; set; }

        [JsonProperty("unidadMedidaId")]
        public int UnidadMedidaUnidadMedidaId { get; set; }
        public string Unidad { get; set; }

        public int? LocalidadId { get; set; }

        [JsonProperty("localidad")]
        public string LocalidadDescripcion { get; set; }

    }
}