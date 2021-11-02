
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class LocalidadToCreateDto
    {

        [JsonProperty("localidad")]
        public string Descripcion { get; set; }
    }
}