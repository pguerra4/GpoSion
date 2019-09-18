using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Dtos
{
    public class ClienteForListDto
    {
        public int ClienteId { get; set; }

        public string Clave { get; set; }

        [Column("Cliente")]
        public string Nombre { get; set; }
    }
}