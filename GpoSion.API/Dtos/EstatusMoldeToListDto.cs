using System;

namespace GpoSion.API.Dtos
{
    public class EstatusMoldeToListDto
    {
        public int EstatusMoldeId { get; set; }
        public string Estatus { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? UltimaModificacion { get; set; }
    }
}