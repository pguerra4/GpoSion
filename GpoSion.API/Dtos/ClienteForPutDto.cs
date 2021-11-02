using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class ClienteForPutDto
    {
        public int ClienteId { get; set; }

        public string Clave { get; set; }

        [JsonProperty("cliente")]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public DateTime UltimaModificacion { get; set; }

        public ClienteForPutDto()
        {
            UltimaModificacion = DateTime.Now;
        }
    }
}