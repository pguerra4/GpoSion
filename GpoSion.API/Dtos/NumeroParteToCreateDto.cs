using System.Collections.Generic;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace GpoSion.API.Dtos
{
    public class NumeroParteToCreateDto
    {

        public string NoParte { get; set; }
        public int ClienteId { get; set; }

        public decimal Peso { get; set; }

        public decimal Costo { get; set; }

        public string Descripcion { get; set; }

        public string LeyendaPieza { get; set; }

        public string UrlImagenPieza { get; set; }


        public int? MaterialId { get; set; }

        public ICollection<MaterialNumeroParteToListDto> Materiales { get; set; }

        public ICollection<MoldeForPutDto> Moldes { get; set; }


    }
}