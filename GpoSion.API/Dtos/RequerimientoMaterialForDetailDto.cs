using System;
using System.Collections.Generic;

namespace GpoSion.API.Dtos
{
    public class RequerimientoMaterialForDetailDto
    {
        public int RequerimientoMaterialId { get; set; }
        public DateTime FechaSolicitud { get; set; }

        public int? TurnoId { get; set; }
        public string TurnoDescripcion { get; set; }

        public string JefaLinea { get; set; }

        public DateTime? Fechaentrega { get; set; }

        public string Almacenista { get; set; }

        public string Recibio { get; set; }

        public string Estatus { get; set; }

        public bool IsRead { get; set; }

        public ICollection<RequerimientoMaterialMaterialForDetailDto> Materiales { get; set; }
    }
}