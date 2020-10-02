using System.Collections.Generic;
using GpoSion.API.Models;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MoldeadoraToEditDto
    {

        public int MoldeadoraId { get; set; }

        [JsonProperty("moldeadora")]
        public string Clave { get; set; }

        public decimal DisparosPorHora { get; set; }


    }
}