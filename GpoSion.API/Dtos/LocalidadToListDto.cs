
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class LocalidadToListDto
    {

        public int LocalidadId { get; set; }

        [JsonProperty("localidad")]
        public string Descripcion { get; set; }
    }
}