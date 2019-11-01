using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class NumeroParteToListDto
    {

        public string NoParte { get; set; }
        public int ClienteId { get; set; }

        [JsonProperty(PropertyName = "cliente")]
        public string ClienteNombre { get; set; }

        public decimal Peso { get; set; }

        public decimal Costo { get; set; }

        public string Descripcion { get; set; }

        public string LeyendaPieza { get; set; }

        public string UrlImagenPieza { get; set; }

        public int? MaterialId { get; set; }
        public string MaterialClaveMaterial { get; set; }

    }
}