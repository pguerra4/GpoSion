using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Viajero
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ViajeroId { get; set; }

        public int MaterialId { get; set; }
        public virtual Material Material { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Existencia { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal ExistenciaProduccion { get; set; }

        public DateTime Fecha { get; set; }

        public virtual ICollection<MovimientoMaterial> MovimientosMaterial { get; set; }

        public int? LocalidadId { get; set; }
        public virtual Localidad Localizacion { get; set; }

        public string Localidad { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


    }
}