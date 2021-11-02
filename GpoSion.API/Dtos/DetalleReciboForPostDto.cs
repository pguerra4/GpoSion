using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class DetalleReciboForPostDto
    {


        public int? TotalCajas { get; set; }

        public Decimal? CantidadPorCaja { get; set; }

        public Decimal Total { get; set; }

        public string Referencia2 { get; set; }
        public int Viajero { get; set; }
        public string ReferenciaCliente { get; set; }

        public string NoLote { get; set; }

        public int ReciboId { get; set; }

        public int MaterialId { get; set; }

        public string Material { get; set; }

        public int UnidadMedidaId { get; set; }

        public int? LocalidadId { get; set; }

        [JsonProperty("localidad")]
        public string LocalidadDescripcion { get; set; }

    }
}