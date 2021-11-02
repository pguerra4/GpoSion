using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Material
    {
        public int MaterialId { get; set; }

        [Column("Material")]
        public string ClaveMaterial { get; set; }

        public string Descripcion { get; set; }

        public int? UnidadMedidaId { get; set; }

        [ForeignKey("UnidadMedidaId")]
        public virtual UnidadMedida UnidadMedida { get; set; }

        public int StockMinimo { get; set; }


        public int? TipoMaterialId { get; set; }

        [ForeignKey("TipoMaterialId")]
        public virtual TipoMaterial TipoMaterial { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }

        [ForeignKey("ModificadoPorId")]
        public virtual User ModificadoPor { get; set; }


        public virtual ICollection<MaterialNumeroParte> MaterialNumerosParte { get; set; }

        public virtual ICollection<LocalidadMaterial> MaterialLocalidades { get; set; }

    }
}