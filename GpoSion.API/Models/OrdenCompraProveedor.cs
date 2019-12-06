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

        public int CompradorId { get; set; }
        public Comprador Comprador { get; set; }

        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        public string PersonaSolicita { get; set; }

        public string Departamento { get; set; }

        public string AreaProyecto { get; set; }

        public string RazonCompra { get; set; }

        public string Compra { get; set; }



        public ICollection<OrdenCompraProveedorDetalle> Materiales { get; set; }

    }
}