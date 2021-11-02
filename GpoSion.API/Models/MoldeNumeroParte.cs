

using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MoldeNumeroParte
    {
        public int MoldeId { get; set; }

        [ForeignKey("MoldeId")]
        public virtual Molde Molde { get; set; }

        public string NoParte { get; set; }

        [ForeignKey("NoParte")]
        public virtual NumeroParte NumeroParte { get; set; }

        public int Cavidades { get; set; }

    }
}