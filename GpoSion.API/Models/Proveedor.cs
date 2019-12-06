using System;
using System.Collections.Generic;

namespace GpoSion.API.Models
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public string Telefono { get; set; }

        public string CondicionesCredito { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime UltimaModificacion { get; set; }

        public ICollection<Recibo> Recibos { get; set; }

    }
}