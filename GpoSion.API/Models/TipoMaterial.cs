using System;

namespace GpoSion.API.Models
{
    public class TipoMaterial
    {
        public int TipoMaterialId { get; set; }
        public string Tipo { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


    }
}