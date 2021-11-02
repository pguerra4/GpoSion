using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Korzh.EasyQuery;
using Microsoft.AspNetCore.Identity;

namespace GpoSion.API.Models
{
    [EqEntity(UseInResult = false, UseInConditions = false)]
    public class User : IdentityUser
    {

        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }

        public bool Activo { get; set; }


        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }

        [ForeignKey("CreadoPorId")]
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }

        [ForeignKey("ModificadoPorId")]
        public virtual User ModificadoPor { get; set; }

    }
}