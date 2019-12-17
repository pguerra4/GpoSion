using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class OrdenCompra
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long NoOrden { get; set; }
        public DateTime Fecha { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public ICollection<OrdenCompraDetalle> NumerosParte { get; set; }

    }
}