using System;

namespace GpoSion.API.Dtos
{
    public class MovimientoProductoToCreateDto
    {
        public string NoParte { get; set; }

        public DateTime Fecha { get; set; }

        public int Cajas { get; set; }

        public int PiezasXCaja { get; set; }

        public int PiezasCertificadas { get; set; }

        public decimal PiezasRechazadas { get; set; }


        public decimal? Purga { get; set; }


        public decimal? Colada { get; set; }

        public string TipoMovimiento { get; set; }

        public int? LocalidadId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int UnidadMedidaIdRechazadas { get; set; }



        public MovimientoProductoToCreateDto()
        {
            FechaCreacion = DateTime.Now;
        }
    }


}