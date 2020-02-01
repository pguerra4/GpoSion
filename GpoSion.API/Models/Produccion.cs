using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Produccion
    {
        public int ProduccionId { get; set; }
        public DateTime Fecha { get; set; }

        public int? MoldeadoraId { get; set; }
        public virtual Moldeadora Moldeadora { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Purga { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal? Colada { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


        public virtual ICollection<ProduccionNumeroParte> ProduccionNumerosParte { get; set; }

    }
}