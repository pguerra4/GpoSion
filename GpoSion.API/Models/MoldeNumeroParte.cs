namespace GpoSion.API.Models
{
    public class MoldeNumeroParte
    {
        public int MoldeId { get; set; }
        public Molde Molde { get; set; }

        public string NoParte { get; set; }
        public NumeroParte NumeroParte { get; set; }

    }
}