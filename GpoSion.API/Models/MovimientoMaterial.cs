using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MovimientoMaterial
    {
        public int MovimientoMaterialId { get; set; }
        public DateTime Fecha { get; set; }

        public Material Material { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Cantidad { get; set; }

        public Area Origen { get; set; }
        public Area Destino { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }


        public Recibo Recibo { get; set; }

        public int? ViajeroId { get; set; }

        public Viajero Viajero { get; set; }

        public int? RequerimientoMaterialMaterialId { get; set; }
        public RequerimientoMaterialMaterial RequerimientoMaterialMaterial { get; set; }

    }
}