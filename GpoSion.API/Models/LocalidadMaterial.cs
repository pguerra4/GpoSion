using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class LocalidadMaterial
    {
        public int LocalidadId { get; set; }

        [ForeignKey("LocalidadId")]
        public virtual Localidad Localidad { get; set; }

        public int MaterialId { get; set; }

        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Existencia { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }

        [ForeignKey("ModificadoPorId")]
        public virtual User ModificadoPor { get; set; }

    }
}