using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MovimientoMoldeadoraNumeroParte
    {
        public int MovimientoMoldeadoraId { get; set; }

        [ForeignKey("MovimientoMoldeadoraId")]
        public virtual MovimientoMoldeadora MovimientoMoldeadora { get; set; }

        public string NoParte { get; set; }

        [ForeignKey("NoParte")]
        public virtual NumeroParte NumeroParte { get; set; }
    }
}