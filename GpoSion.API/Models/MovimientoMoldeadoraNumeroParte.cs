namespace GpoSion.API.Models
{
    public class MovimientoMoldeadoraNumeroParte
    {
        public int MovimientoMoldeadoraId { get; set; }
        public MovimientoMoldeadora MovimientoMoldeadora { get; set; }

        public string NoParte { get; set; }
        public NumeroParte NumeroParte { get; set; }
    }
}