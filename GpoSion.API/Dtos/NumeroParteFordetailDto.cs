using System.Collections.Generic;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class NumeroParteForDetailDto
    {

        public string NoParte { get; set; }
        public int ClienteId { get; set; }

        [JsonProperty("cliente")]
        public string ClienteNombre { get; set; }

        public decimal Peso { get; set; }

        public decimal Costo { get; set; }

        public string Descripcion { get; set; }

        public string LeyendaPieza { get; set; }

        public string UrlImagenPieza { get; set; }

        public ICollection<MaterialNumeroParteToListDto> Materiales { get; set; }

        public ICollection<MoldeNumeroParteToListDto> Moldes { get; set; }

    }
}