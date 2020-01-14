using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class LocalidadToCreateDto
    {

        [JsonProperty(PropertyName = "localidad")]
        public string Descripcion { get; set; }
    }
}