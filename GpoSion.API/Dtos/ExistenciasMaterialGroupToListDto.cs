using System;

namespace GpoSion.API.Dtos
{
    public class ExistenciasMaterialGroupToListDto
    {
        public int MaterialId { get; set; }
        public string Material { get; set; }
        public decimal Almacen { get; set; }

        public decimal Produccion { get; set; }

        public string Cliente { get; set; }

        public DateTime UltimaModificacion { get; set; }
    }
}