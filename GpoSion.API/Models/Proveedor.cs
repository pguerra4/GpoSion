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
        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }


        public virtual ICollection<Recibo> Recibos { get; set; }

    }
}