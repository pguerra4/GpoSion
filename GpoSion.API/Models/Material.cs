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

        public UnidadMedida UnidadMedida { get; set; }


        public int? TipoMaterialId { get; set; }
        public TipoMaterial TipoMaterial { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }

        public ICollection<MaterialNumeroParte> MaterialNumerosParte { get; set; }

    }
}