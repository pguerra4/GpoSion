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
        public virtual Cliente Cliente { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


        public virtual ICollection<OrdenCompraDetalle> NumerosParte { get; set; }

        public virtual ICollection<HistorialOrdenCompra> Historial { get; set; }

    }
}