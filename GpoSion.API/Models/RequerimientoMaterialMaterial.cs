using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class RequerimientoMaterialMaterial
    {
        public int Id { get; set; }
        public int RequerimientoMaterialId { get; set; }

        [ForeignKey("RequerimientoMaterialId")]
        public virtual RequerimientoMaterial Requerimiento { get; set; }

        public int MaterialId { get; set; }

        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }

        public int? ViajeroId { get; set; }

        [ForeignKey("ViajeroId")]
        public virtual Viajero Viajero { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public Decimal Cantidad { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public Decimal CantidadEntregada { get; set; }

        public int UnidadMedidaId { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public virtual UnidadMedida UnidadMedida { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public string Estatus { get; set; }


    }
}