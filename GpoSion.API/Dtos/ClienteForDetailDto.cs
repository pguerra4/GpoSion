using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Dtos
{
    public class ClienteForDetailDto
    {
        public int ClienteId { get; set; }


        public string Clave { get; set; }

        [Column("Cliente")]
        public string Nombre { get; set; }

        public string Direccion { get; set; }


        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }
    }
}