using System;
using System.Collections.Generic;

namespace GpoSion.API.Dtos
{
    public class RequerimientoforCreationDto
    {

        public DateTime FechaSolicitud { get; set; }

        public int? TurnoId { get; set; }

        public string JefaLinea { get; set; }

        public ICollection<RequerimientoMaterialMaterialForCreationDto> Materiales { get; set; }
    }
}