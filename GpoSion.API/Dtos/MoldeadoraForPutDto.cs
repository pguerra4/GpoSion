using System;
using System.Collections.Generic;


namespace GpoSion.API.Dtos
{
    public class MoldeadoraForPutDto
    {
        public int MoldeadoraId { get; set; }

        public string Estatus { get; set; }

        public int? MoldeId { get; set; }

        public int? MaterialId { get; set; }

        public DateTime? UltimaModificacion { get; set; }

        public ICollection<string> NumerosParte { get; set; }
        public MoldeadoraForPutDto()
        {
            UltimaModificacion = DateTime.Now;
        }

    }
}