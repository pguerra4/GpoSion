namespace GpoSion.API.Models
{
    public class MoldeadoraNumeroParte
    {
        public int MoldeadoraId { get; set; }
        public Moldeadora Moldeadora { get; set; }

        public string NoParte { get; set; }
        public NumeroParte NumeroParte { get; set; }

    }
}