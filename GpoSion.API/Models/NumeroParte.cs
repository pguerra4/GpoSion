using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class NumeroParte
    {
        [Key]
        public string NoParte { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public decimal Peso { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Costo { get; set; }

        public string Descripcion { get; set; }

        public string LeyendaPieza { get; set; }

        public string UrlImagenPieza { get; set; }

        public int? MaterialId { get; set; }
        public Material Material { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }


        public ICollection<MoldeadoraNumeroParte> MoldeadorasNumeroParte { get; set; }

        public ICollection<MoldeNumeroParte> MoldesNumeroParte { get; set; }

        public ICollection<MaterialNumeroParte> MaterialesNumeroParte { get; set; }

        public ICollection<OrdenCompraDetalle> OrdenesCompraDetalle { get; set; }

        public ICollection<MovimientoMoldeadoraNumeroParte> MovimientosMoldeadoraNumeroParte { get; set; }

        public ICollection<ExistenciaProducto> ExistenciasProducto { get; set; }
    }
}