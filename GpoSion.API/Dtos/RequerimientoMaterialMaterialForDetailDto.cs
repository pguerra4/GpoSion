using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class RequerimientoMaterialMaterialForDetailDto
    {
        public int Id { get; set; }
        public int RequerimientoMaterialId { get; set; }

        public int MaterialId { get; set; }

        [JsonProperty("material")]
        public string MaterialClaveMaterial { get; set; }

        public int ViajeroId { get; set; }
        public int ViajeroNoViajero { get; set; }

        public Decimal Cantidad { get; set; }

        public Decimal CantidadEntregada { get; set; }

        public int UnidadMedidaId { get; set; }
        public string UnidadMedidaUnidad { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public string Estatus { get; set; }

    }
}