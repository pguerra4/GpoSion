using System;
using System.Collections.Generic;

namespace GpoSion.API.Models
{
    public class Moldeadora
    {
        public int MoldeadoraId { get; set; }

        public string Clave { get; set; }

        public string Estatus { get; set; }

        public int? MoldeId { get; set; }

        public Molde Molde { get; set; }

        public int? MaterialId { get; set; }
        public Material Material { get; set; }

        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public User ModificadoPor { get; set; }


        public int? UltimoMotivoParo { get; set; }

        public ICollection<MoldeadoraNumeroParte> MoldeadoraNumerosParte { get; set; }

        public ICollection<MovimientoMoldeadora> MovimientosMoldeadora { get; set; }

    }
}