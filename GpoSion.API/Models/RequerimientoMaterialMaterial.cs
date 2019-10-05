using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class RequerimientoMaterialMaterial
    {
        public int Id { get; set; }
        public int RequerimientoMaterialId { get; set; }
        public RequerimientoMaterial Requerimiento { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int ViajeroId { get; set; }
        public Viajero Viajero { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public Decimal Cantidad { get; set; }

        public int UnidadMedidaId { get; set; }
        public UnidadMedida UnidadMedida { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public string Estatus { get; set; }


    }
}