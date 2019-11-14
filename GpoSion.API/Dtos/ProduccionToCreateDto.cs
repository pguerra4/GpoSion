using System;
using System.Collections.Generic;

namespace GpoSion.API.Dtos
{
    public class ProduccionToCreateDto
    {

        public DateTime Fecha { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int? MoldeadoraId { get; set; }

        public decimal? Purga { get; set; }

        public decimal? Colada { get; set; }

        public ICollection<ProduccionNumeroParteToCreateDto> ProduccionNumerosParte { get; set; }


        public ProduccionToCreateDto()
        {
            FechaCreacion = DateTime.Now;
        }

    }


}