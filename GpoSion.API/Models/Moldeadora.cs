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

        public DateTime? UltimaModificacion { get; set; }

        public ICollection<MoldeadoraNumeroParte> MoldeadoraNumerosParte { get; set; }

        public ICollection<MovimientoMoldeadora> MovimientosMoldeadora { get; set; }

    }
}