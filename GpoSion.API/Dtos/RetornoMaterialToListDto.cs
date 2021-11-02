using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class RetornoMaterialToListDto
    {
        public int MovimientoMaterialId { get; set; }

        public DateTime Fecha { get; set; }


        public int MaterialId { get; set; }

        [JsonProperty("material")]
        public string MaterialClaveMaterial { get; set; }

        public int LocalidadId { get; set; }

        [JsonProperty("localidad")]
        public string LocalidadDescripcion { get; set; }

        public decimal Cantidad { get; set; }

    }
}