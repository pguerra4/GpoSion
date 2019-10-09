using System;

namespace GpoSion.API.Dtos
{
    public class RequerimientoMaterialMaterialForCreationDto
    {


        public int MaterialId { get; set; }

        public Decimal Cantidad { get; set; }

        public int UnidadMedidaId { get; set; }

        public string Estatus { get; set; }

    }


}