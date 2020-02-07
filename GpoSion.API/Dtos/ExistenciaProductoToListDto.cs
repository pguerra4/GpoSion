using System;


namespace GpoSion.API.Dtos
{
    public class ExistenciaProductoToListDto
    {
        public int ExistenciaProductoId { get; set; }

        public string NoParte { get; set; }


        public int PiezasCertificadas { get; set; }
        public int PiezasRechazadas { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }

        public string CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }

        public string ModificadoPor { get; set; }
    }
}