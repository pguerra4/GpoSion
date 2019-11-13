using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class NumeroParteForDetailDto
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

        public ICollection<MaterialtoListDto> Materiales { get; set; }

        public ICollection<MoldeToListDto> Moldes { get; set; }

    }
}