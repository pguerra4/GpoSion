using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class OrdenCompraToListDto
    {

        public int NoOrden { get; set; }
        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }

        [JsonProperty(PropertyName = "cliente")]
        public string ClienteNombre { get; set; }

        public ICollection<OrdenCompraDetalleToListDto> NumerosParte { get; set; }
    }
}