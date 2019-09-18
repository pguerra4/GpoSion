using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class ExistenciaMaterial
    {

        public int ExistenciaMaterialId { get; set; }
        public Material Material { get; set; }
        public Area Area { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Existencia { get; set; }

    }
}