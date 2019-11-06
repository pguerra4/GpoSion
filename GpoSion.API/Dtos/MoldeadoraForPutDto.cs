using System.Collections.Generic;
using GpoSion.API.Models;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class MoldeadoraForPutDto
    {
        public int MoldeadoraId { get; set; }

        public string Estatus { get; set; }

        public int? MoldeId { get; set; }

        public int? MaterialId { get; set; }

        public ICollection<string> NumerosParte { get; set; }
    }
}