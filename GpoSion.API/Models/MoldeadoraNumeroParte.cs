namespace GpoSion.API.Models
{
    public class MoldeadoraNumeroParte
    {
        public int MoldeadoraId { get; set; }
        public virtual Moldeadora Moldeadora { get; set; }

        public string NoParte { get; set; }
        public virtual NumeroParte NumeroParte { get; set; }

    }
}