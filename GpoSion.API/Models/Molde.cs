using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Molde
    {

        public int Id { get; set; }

        [Column("Molde")]
        public string ClaveMolde { get; set; }

        public int? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int? UbicacionAreaId { get; set; }
        public virtual Area Ubicacion { get; set; }

        // public int? MaquinaMoldeadoraId { get; set; }
        // public Moldeadora Maquina { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


        public virtual ICollection<MoldeNumeroParte> MoldeNumerosParte { get; set; }

    }
}