using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GpoSion.API.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }


        public string Clave { get; set; }

        [Column("Cliente")]
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }

        public virtual ICollection<OrdenCompra> OrdenesCompra { get; set; }

        public virtual ICollection<NumeroParte> NumerosParte { get; set; }
    }
}