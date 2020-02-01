using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Localidad
    {
        public int LocalidadId { get; set; }

        [Column("Localidad")]
        public string Descripcion { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }

        public virtual ICollection<LocalidadMaterial> MaterialesLocalidad { get; set; }

        public virtual ICollection<LocalidadNumeroParte> NumerosParteLocalidad { get; set; }

    }
}