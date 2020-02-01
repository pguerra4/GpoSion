using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MaterialNumeroParte
    {
        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public string NoParte { get; set; }
        public virtual NumeroParte NumeroParte { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Cantidad { get; set; }
    }
}