using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class DetalleReciboForPutDto
    {
        public int DetalleReciboId { get; set; }
        public int? TotalCajas { get; set; }

        public Decimal? CantidadPorCaja { get; set; }

        public Decimal Total { get; set; }

        public string Referencia2 { get; set; }
        public int Viajero { get; set; }
        public string ReferenciaCliente { get; set; }

        public int ReciboId { get; set; }

        public int MaterialId { get; set; }

        public int UnidadMedidaId { get; set; }

        public int? LocalidadId { get; set; }

        [JsonProperty(PropertyName = "localidad")]
        public string LocalidadDescripcion { get; set; }

        public string MotivoMovimiento { get; set; }

    }
}