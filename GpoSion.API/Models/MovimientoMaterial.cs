using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class MovimientoMaterial
    {
        public int MovimientoMaterialId { get; set; }
        public DateTime Fecha { get; set; }

        public int? MaterialId { get; set; }

        [ForeignKey("MaterialId")]
        public virtual Material Material { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Cantidad { get; set; }

        public int? OrigenAreaId { get; set; }

        [ForeignKey("OrigenAreaId")]
        public virtual Area Origen { get; set; }

        public int? DestinoAreaId { get; set; }

        [ForeignKey("DestinoAreaId")]
        public virtual Area Destino { get; set; }

        public string MotivoMovimiento { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }

        [ForeignKey("ModificadoPorId")]
        public virtual User ModificadoPor { get; set; }

        public int? ReciboId { get; set; }

        [ForeignKey("ReciboId")]
        public virtual Recibo Recibo { get; set; }

        public int? ViajeroId { get; set; }

        [ForeignKey("ViajeroId")]
        public virtual Viajero Viajero { get; set; }

        public int? LocalidadId { get; set; }

        [ForeignKey("LocalidadId")]
        public virtual Localidad Localidad { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal? ExistenciaInicial { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal? ExistenciaFinal { get; set; }

        public int? RequerimientoMaterialMaterialId { get; set; }

        [ForeignKey("RequerimientoMaterialMaterialId")]
        public virtual RequerimientoMaterialMaterial RequerimientoMaterialMaterial { get; set; }

    }
}