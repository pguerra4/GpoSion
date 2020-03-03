using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Korzh.EasyQuery;

namespace GpoSion.API.Models
{
    public class NumeroParte
    {
        [Key]
        public string NoParte { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Peso { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Costo { get; set; }

        [EqEntityAttr(UseInResult = true, UseInConditions = false)]
        public string Descripcion { get; set; }

        [EqEntityAttr(UseInResult = true, UseInConditions = false)]
        public string LeyendaPieza { get; set; }

        [EqEntityAttr(UseInResult = true, UseInConditions = false)]
        public string UrlImagenPieza { get; set; }

        public int? MaterialId { get; set; }
        public virtual Material Material { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


        public virtual ICollection<MoldeadoraNumeroParte> MoldeadorasNumeroParte { get; set; }

        public virtual ICollection<MoldeNumeroParte> MoldesNumeroParte { get; set; }

        public virtual ICollection<MaterialNumeroParte> MaterialesNumeroParte { get; set; }

        public virtual ICollection<OrdenCompraDetalle> OrdenesCompraDetalle { get; set; }

        public virtual ICollection<MovimientoMoldeadoraNumeroParte> MovimientosMoldeadoraNumeroParte { get; set; }

        public virtual ICollection<ExistenciaProducto> ExistenciasProducto { get; set; }

        public virtual ICollection<LocalidadNumeroParte> NumeroParteLocalidades { get; set; }

        public virtual ICollection<ExistenciaProductoProduccion> ExistenciasProductoProduccion { get; set; }
    }
}