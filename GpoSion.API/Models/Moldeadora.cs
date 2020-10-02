using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Moldeadora
    {
        public int MoldeadoraId { get; set; }

        public string Clave { get; set; }

        public string Estatus { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal DisparosPorHora { get; set; }

        public int? MoldeId { get; set; }

        public virtual Molde Molde { get; set; }

        public int? MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


        public int? UltimoMotivoParo { get; set; }

        public virtual ICollection<MoldeadoraNumeroParte> MoldeadoraNumerosParte { get; set; }

        public virtual ICollection<MovimientoMoldeadora> MovimientosMoldeadora { get; set; }

    }
}