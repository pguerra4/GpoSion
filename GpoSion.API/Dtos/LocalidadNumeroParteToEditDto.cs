namespace GpoSion.API.Dtos
{
    public class LocalidadNumeroParteToEditDto
    {
        public int LocalidadId { get; set; }

        public string NoParte { get; set; }

        public decimal Existencia { get; set; }

        public string Motivo { get; set; }
    }
}