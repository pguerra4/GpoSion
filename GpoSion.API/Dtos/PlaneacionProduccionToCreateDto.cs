
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class PlaneacionProduccionToCreateDto
    {

        [JsonProperty("year")]
        public int año { get; set; }

        public int semana { get; set; }

        public string NoParte { get; set; }

        public int cantidad { get; set; }
    }
}