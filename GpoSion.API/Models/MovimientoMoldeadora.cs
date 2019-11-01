using System;

namespace GpoSion.API.Models
{
    public class MovimientoMoldeadora
    {
        public int MovimientoMoldeadoraId { get; set; }
        public string Movimiento { get; set; }

        public string Observaciones { get; set; }

        public DateTime Fecha { get; set; }

        public int? ModificadoPorId { get; set; }
        public Usuario ModificadoPor { get; set; }

        public string Estatus { get; set; }

        public int? MoldeId { get; set; }
        public Molde Molde { get; set; }

        public int? MaterialId { get; set; }
        public Material Material { get; set; }

        public string NumeroParteId { get; set; }
        public NumeroParte NumeroParte { get; set; }


    }
}