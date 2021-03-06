using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class LocalidadMaterial
    {
        public int LocalidadId { get; set; }
        public virtual Localidad Localidad { get; set; }

        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Existencia { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }

    }
}