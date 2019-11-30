using System;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class ClienteToCreateDto
    {
        public string Clave { get; set; }

        [JsonProperty(PropertyName = "cliente")]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ClienteToCreateDto()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}