using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Viajero
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ViajeroId { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Existencia { get; set; }
        public DateTime Fecha { get; set; }
    }
}