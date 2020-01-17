using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class ExistenciaMaterial
    {

        public int ExistenciaMaterialId { get; set; }
        public Material Material { get; set; }
        public Area Area { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Existencia { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }



    }
}