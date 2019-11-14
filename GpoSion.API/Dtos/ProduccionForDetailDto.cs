using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class ProduccionForDetailDto
    {

        public int ProduccionId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int? MoldeadoraId { get; set; }

        [JsonProperty("moldeadora")]
        public string MoldeadoraMoldeadora { get; set; }

        public decimal? Purga { get; set; }

        public decimal? Colada { get; set; }

        public ICollection<ProduccionNumeroParteToCreateDto> ProduccionNumerosParte { get; set; }


    }


}