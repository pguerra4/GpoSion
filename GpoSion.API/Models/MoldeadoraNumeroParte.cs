using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MoldeadoraNumeroParte
    {
        public int MoldeadoraId { get; set; }

        [ForeignKey("MoldeadoraId")]
        public virtual Moldeadora Moldeadora { get; set; }

        public string NoParte { get; set; }

        [ForeignKey("NoParte")]
        public virtual NumeroParte NumeroParte { get; set; }

    }
}