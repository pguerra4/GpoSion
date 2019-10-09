using System;
using System.Collections.Generic;

namespace GpoSion.API.Dtos
{
    public class RequerimientoforEditDto
    {

        public int RequerimientoMaterialId { get; set; }

        public string Almacenista { get; set; }
        public string Recibio { get; set; }

        public decimal Total { get; set; }


        public ICollection<RequerimientoMaterialMaterialForEditDto> Items { get; set; }
    }


}