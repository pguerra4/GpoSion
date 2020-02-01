namespace GpoSion.API.Models
{
    public class MovimientoMoldeadoraNumeroParte
    {
        public int MovimientoMoldeadoraId { get; set; }
        public virtual MovimientoMoldeadora MovimientoMoldeadora { get; set; }

        public string NoParte { get; set; }
        public virtual NumeroParte NumeroParte { get; set; }
    }
}