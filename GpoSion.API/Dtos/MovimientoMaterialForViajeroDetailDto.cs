using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MovimientoMaterialForViajeroDetailDto
    {
        public DateTime Fecha { get; set; }

        [JsonProperty(PropertyName = "material")]
        public string MaterialClaveMaterial { get; set; }

        public decimal Cantidad { get; set; }

        [JsonProperty(PropertyName = "origen")]
        public string OrigenNombreArea { get; set; }

        [JsonProperty(PropertyName = "destino")]
        public string DestinoNombreArea { get; set; }

        [JsonProperty(PropertyName = "modificadoPor")]
        public string ModificadoPorUserName { get; set; }

        [JsonProperty(PropertyName = "creadoPor")]
        public string CreadoPorUserName { get; set; }

        public string MotivoMovimiento { get; set; }

    }
}