using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class OrdenCompraProveedor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string NoOrden { get; set; }
        public DateTime Fecha { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public int CompradorId { get; set; }
        public virtual Comprador Comprador { get; set; }

        public int ProveedorId { get; set; }
        public virtual Proveedor Proveedor { get; set; }

        public string PersonaSolicita { get; set; }

        public string Departamento { get; set; }

        public string AreaProyecto { get; set; }

        public string RazonCompra { get; set; }

        public string Compra { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }




        public virtual ICollection<OrdenCompraProveedorDetalle> Materiales { get; set; }

    }
}