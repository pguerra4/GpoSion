using System;

namespace GpoSion.API.Dtos
{
    public class ProveedorForPutDto
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public string CondicionesCredito { get; set; }

        public DateTime UltimaModificacion { get; set; }

        public ProveedorForPutDto()
        {
            UltimaModificacion = DateTime.Now;
        }

    }
}