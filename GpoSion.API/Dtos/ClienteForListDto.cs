using Newtonsoft.Json;


namespace GpoSion.API.Dtos
{
    public class ClienteForListDto
    {
        public int ClienteId { get; set; }

        public string Clave { get; set; }

        [JsonProperty("cliente")]
        public string Nombre { get; set; }
    }
}