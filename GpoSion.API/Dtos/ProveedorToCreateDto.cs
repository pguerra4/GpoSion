using System;

namespace GpoSion.API.Dtos
{
    public class ProveedorToCreateDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public string Telefono { get; set; }
        public DateTime FechaCreacion { get; set; }

        public ProveedorToCreateDto()
        {
            FechaCreacion = DateTime.Now;
        }
    }
}