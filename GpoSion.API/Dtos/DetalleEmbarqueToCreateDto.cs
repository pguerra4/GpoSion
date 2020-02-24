namespace GpoSion.API.Dtos
{
    public class DetalleEmbarqueToCreateDto
    {

        public int EmbarqueId { get; set; }

        public string NoParte { get; set; }

        public long? NoOrden { get; set; }

        public int Cajas { get; set; }
        public int PiezasXCaja { get; set; }

        public int Entregadas { get; set; }

        public int? LocalidadId { get; set; }

    }
}