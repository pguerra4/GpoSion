using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Area
    {
        public int AreaId { get; set; }

        [Column("Area")]
        public string NombreArea { get; set; }

        public string Abreviatura { get; set; }

    }
}