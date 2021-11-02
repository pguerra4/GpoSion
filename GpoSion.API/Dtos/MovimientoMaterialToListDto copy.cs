using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MovimientoMaterialToListDto
    {
        public DateTime Fecha { get; set; }

        [JsonProperty("material")]
        public string MaterialClaveMaterial { get; set; }

        public decimal Cantidad { get; set; }

        [JsonProperty("origen")]
        public string OrigenNombreArea { get; set; }

        [JsonProperty("destino")]
        public string DestinoNombreArea { get; set; }

        [JsonProperty("modificadoPor")]
        public string ModificadoPorUserName { get; set; }

        [JsonProperty("creadoPor")]
        public string CreadoPorUserName { get; set; }

        public string MotivoMovimiento { get; set; }

        public int? LocalidadId { get; set; }

        [JsonProperty("localidad")]
        public string LocalidadDescripcion { get; set; }

        public decimal? ExistenciaInicial { get; set; }

        public decimal? ExistenciaFinal { get; set; }


    }
}