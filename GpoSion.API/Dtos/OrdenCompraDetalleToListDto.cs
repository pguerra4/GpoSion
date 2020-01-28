using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class OrdenCompraDetalleToListDto
    {
        public int Id { get; set; }

        [JsonProperty(PropertyName = "noParte")]
        public string NumeroParteNoParte { get; set; }

        public long NoOrden { get; set; }

        public Decimal Precio { get; set; }

        public int PiezasAutorizadas { get; set; }

        public int PiezasSurtidas { get; set; }

        public DateTime UltimaModificacion { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaFin { get; set; }

        public string Observaciones { get; set; }


    }


}