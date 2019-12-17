namespace GpoSion.API.Dtos
{
    public class DetalleEmbarqueToListDto
    {
        public int DetalleEmbarqueId { get; set; }

        public int EmbarqueId { get; set; }

        public string NoParte { get; set; }

        public long? NoOrden { get; set; }

        public int Cajas { get; set; }
        public int PiezasXCaja { get; set; }

        public int Entregadas { get; set; }

    }
}