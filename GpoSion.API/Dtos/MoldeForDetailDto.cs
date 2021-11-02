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

        [JsonProperty("clienteId")]
        public int ClienteClienteId { get; set; }

        [JsonProperty("cliente")]
        public string ClienteNombre { get; set; }

        [JsonProperty("ubicacionId")]
        public int UbicacionAreaId { get; set; }

        [JsonProperty("ubicacion")]
        public string UbicacionNombreArea { get; set; }

        [JsonProperty("moldeadoraId")]
        public int? MoldeadoraMoldeadoraId { get; set; }
        [JsonProperty("moldeadora")]
        public String MoldeadoraClave { get; set; }

        [JsonProperty("estatusMoldeId")]
        public int? EstatusMoldeId { get; set; }

        [JsonProperty("estatusMolde")]
        public String EstatusEstatus { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }

        public string[] NumerosParte { get; set; }

        public ICollection<MovimientoMoldeForListDto> Movimientos { get; set; }


    }
}