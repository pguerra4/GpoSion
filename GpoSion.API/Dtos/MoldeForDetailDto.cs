using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MoldeForDetailDto
    {



        public int Id { get; set; }

        [JsonProperty("molde")]
        public string ClaveMolde { get; set; }

        [JsonProperty(PropertyName = "clienteId")]
        public int ClienteClienteId { get; set; }

        [JsonProperty(PropertyName = "cliente")]
        public string ClienteNombre { get; set; }

        [JsonProperty(PropertyName = "ubicacionId")]
        public int UbicacionAreaId { get; set; }

        [JsonProperty(PropertyName = "ubicacion")]
        public string UbicacionNombreArea { get; set; }

        [JsonProperty(PropertyName = "moldeadoraId")]
        public int? MoldeadoraMoldeadoraId { get; set; }
        [JsonProperty(PropertyName = "moldeadora")]
        public String MoldeadoraClave { get; set; }

        [JsonProperty(PropertyName = "estatusMoldeId")]
        public int? EstatusMoldeId { get; set; }

        [JsonProperty(PropertyName = "estatusMolde")]
        public String EstatusEstatus { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }

        public string[] NumerosParte { get; set; }

        public ICollection<MovimientoMoldeForListDto> Movimientos { get; set; }


    }
}