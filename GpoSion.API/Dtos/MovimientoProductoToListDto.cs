using System;

namespace GpoSion.API.Dtos
{
    public class MovimientoProductoToListDto
    {
        public int MovimientoProductoId { get; set; }
        public string NoParte { get; set; }

        public DateTime Fecha { get; set; }

        public int Cajas { get; set; }

        public int PiezasXCaja { get; set; }

        public int PiezasCertificadas { get; set; }

        public int PiezasRechazadas { get; set; }


        public decimal? Purga { get; set; }


        public decimal? Colada { get; set; }

        public string TipoMovimiento { get; set; }

        public string Localidad { get; set; }



    }


}