using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MoldeadoraToCreateDto
    {

        [JsonProperty("moldeadora")]
        public string Clave { get; set; }

        public decimal? DisparosPorHora { get; set; }


    }
}