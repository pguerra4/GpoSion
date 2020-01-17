using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class OrdenCompraProveedorDetalle
    {
        public int Id { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }
        public string NoOrden { get; set; }

        public OrdenCompraProveedor OrdenCompraProveedor { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public Decimal Cantidad { get; set; }

        public string UnidadMedida { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public Decimal PrecioUnitario { get; set; }

        [Column(TypeName = "decimal(18, 4)")]
        public Decimal PrecioTotal { get; set; }

        public string Observaciones { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }



    }
}