
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MoldeNumeroParteToListDto
    {
        public int MoldeId { get; set; }

        public MoldeToListDto Molde { get; set; }

        [JsonProperty("noParte")]
        public string NoParte { get; set; }

        public int Cavidades { get; set; }
    }
}