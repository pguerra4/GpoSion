using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GpoSion.API.Models
{
    public class User : IdentityUser
    {

        public string Nombre { get; set; }
        public string Paterno { get; set; }
        public string Materno { get; set; }

        public bool Activo { get; set; }


        public DateTime? FechaCreacion { get; set; }
        public DateTime? UltimaModificacion { get; set; }
        public string CreadoPorId { get; set; }
        public virtual User CreadoPor { get; set; }

        public string ModificadoPorId { get; set; }
        public virtual User ModificadoPor { get; set; }

    }
}