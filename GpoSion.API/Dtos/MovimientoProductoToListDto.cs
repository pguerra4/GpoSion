using System;
using Newtonsoft.Json;

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

        public int? LocalidadId { get; set; }

        [JsonProperty("localidad")]
        public string LocalidadDescripcion { get; set; }

        public int? ExistenciaAlmacenInicial { get; set; }


        public int? ExistenciaAlmacenFinal { get; set; }



    }


}