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
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }

        public ICollection<OrdenCompra> OrdenesCompra { get; set; }

        public ICollection<NumeroParte> NumerosParte { get; set; }
    }
}