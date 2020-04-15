

namespace GpoSion.API.Models
{
    public class MoldeNumeroParte
    {
        public int MoldeId { get; set; }
        public virtual Molde Molde { get; set; }

        public string NoParte { get; set; }
        public virtual NumeroParte NumeroParte { get; set; }

        public int Cavidades { get; set; }

    }
}