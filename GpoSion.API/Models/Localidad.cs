using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Localidad
    {
        public int LocalidadId { get; set; }

        [Column("Localidad")]
        public string Descripcion { get; set; }
    }
}